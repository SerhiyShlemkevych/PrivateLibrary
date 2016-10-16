using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Timers;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using EpamTask.PrivateLibrary.Entity.Book;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Entity.Models;
using EpamTask.PrivateLibrary.Entity.User;
using EpamTask.PrivateLibrary.Parser.Book;
using EpamTask.PrivateLibrary.Parser.BorrowBook;
using EpamTask.PrivateLibrary.Parser.Member;
using EpamTask.PrivateLibrary.Global;

namespace EpamTask.PrivateLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow
    {
        //if application like this one that fully relies on database, do we still need a new thread to 'load/connect'? 
        //since there is literally no use of UI until we got a response back.
        public MainWindow(UserEntity user)
        {
            InitializeComponent();
            Container.CurrentUserId = user.ID;
            comboBoxMemberGender.Items.Add("Male");
            comboBoxMemberGender.Items.Add("Female");

            var statusClear = new Timer();
            statusClear.Interval = 5000;
            statusClear.Elapsed += StatusTimeElapsed;
            statusClear.Enabled = true;
        }
        
        #region MainWindow
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnBookList.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }
        private void dataGridMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = null; //without it switching between books causes loss of 'shelf'
            DataContext = dataGridMain.SelectedItem;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCategory.SelectedItem == null)
                return;
            IEnumerable<object> table;
            switch (Container.CurrentTable)
            {
                case TableType.Book:
                    table = Container.BookList;
                    break;
                case TableType.Member:
                    table = Container.MemberList;
                    break;
                default:
                    table = Container.BorrowList;
                    break;
            }
            var category = comboBoxCategory.SelectedItem.ToString();
            var searchResult = from data in table
                                       where data.GetType().GetProperty(category).GetValue(data, null).ToString().StartsWith(txtSearch.Text, StringComparison.CurrentCultureIgnoreCase)
                                       select data;
            dataGridMain.ItemsSource = searchResult;
        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString))
            {
                    conn.Open();
                    gridTableSelect.IsEnabled = true;
                    gridTableForm.IsEnabled = true;
                    btnSignup.IsEnabled = true;
                    lblStatus.Content = "You're connected to DB!";
                    lblStatus.Foreground = Brushes.Green;
            }
        }
        private void btnRefreshAll_Click(object sender, RoutedEventArgs e)
        {
            LoadBookTable();
            LoadMemberTable();
            LoadBookTable();
            lblStatus.Content = "Database was successfully refreshed!";
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        #endregion mainWindow

        #region TableSelectButtons
        private void btnBookList_Click(object sender, RoutedEventArgs e)
        {
                LoadBookTable();
                dataGridMain.ItemsSource = Container.BookList;
                dataGridMain.SelectedIndex = 0;
                SwitchToGrid(gridBook);
                Container.CurrentTable = TableType.Book;

        }
        private void btnMemberList_Click(object sender, RoutedEventArgs e)
        {
            LoadMemberTable();
            dataGridMain.ItemsSource = Container.MemberList;
            dataGridMain.SelectedIndex = 0;
            SwitchToGrid(gridMember);
            Container.CurrentTable = TableType.Member;
        }
        private void btnRental_Click(object sender, RoutedEventArgs e)
        {
            LoadBookTable();
            LoadMemberTable();
            LoadBorrowTable();
            dataGridMain.ItemsSource = Container.BorrowList;
            DataContext = null;
            SwitchToGrid(gridBorrow);
            Container.CurrentTable = TableType.BorrowList;
        }               
        #endregion TableSelectButtons        

        #region BookForms
        private void btnBookEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsGridValid(gridBook))
            {
                ShowValidationError();
                return;
            }
            var book = DataContext as BookEntity;
            if (book == null) return;
            var message = "Confirm editing the book with ID[" + book.ID + "],\n\"" + book.Name + "\" By " + book.Author;  Container.UnitOfWork.BookRepository.Update(book);
            if (ShowConfirmationWindow(message, "Editing a book"))
            {
                var wasSuccesful = Container.UnitOfWork.BookRepository.Update(book);
                StatusQuerySuccess(wasSuccesful);
            }
        }
        private void btnBookAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!IsGridValid(gridBook))
            {
                ShowValidationError();
                return;
            }
            var book = DataContext as BookEntity;
            if (book == null) return;
            var message = "Confirm adding book with ID[" + book.ID + "],\n\"" + book.Name + "\" By " + book.Author;
            if (ShowConfirmationWindow(message, "Adding a book"))
            {
                var wasSuccesful = Container.UnitOfWork.BookRepository.Add(book);
                StatusQuerySuccess(wasSuccesful);
                DataContext = null;
            }
        }
        private void btnBookDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!txtBookID.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please select a book", "Selection failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var book = DataContext as BookEntity;
            if (book == null) return;
            var message = "Confirm deleting the book with ID[" + book.ID + "],\n\"" + book.Name + "\" By " + book.Author;
            if (ShowConfirmationWindow(message, "Deleting a book"))
            {
                var wasSuccesful = Container.UnitOfWork.BookRepository.Delete(book.ID);
                StatusQuerySuccess(wasSuccesful);
                DataContext = null;
            }
        }
        private void btnBookRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadBookTable();
            dataGridMain.ItemsSource = Container.BookList;
        }
        private void btnClearBook_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
        }
        private void comboBoxBookFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxBookFloor.SelectedItem != null)
            {
                comboBoxBookShelf.ItemsSource = (from list in Container.BookLocationList
                                                 where list.Floor == (int)comboBoxBookFloor.SelectedItem
                                                 select list.Shelf).Distinct();

            }
        }
        #endregion BookForms

        #region MemberForms              
        private void btnMemberEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsGridValid(gridMember))
            {
                ShowValidationError();
                return;
            }
            var member = DataContext as MemberEntity;
            if (member == null) return;
            var message = "Confirm editing member's information: ID[" + member.ID + "],\nName: " + member.FirstName + " " + member.LastName + "\n Subscription: " + member.MembershipName;
            if (ShowConfirmationWindow(message, "Deleting a book"))
            {
                var wasSuccesful = Container.UnitOfWork.MemberRepository.Update(member);
                StatusQuerySuccess(wasSuccesful);
            }
        }
        private void btnMemberDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!txtMemberID.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please select a member", "Selection failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var member = DataContext as MemberEntity;
            if (member == null) return;
            var joinDate = DateTime.ParseExact(member.JoinDate.Replace('.','/'), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (joinDate < DateTime.Now.AddDays(-14))
            {
                MessageBox.Show("Deleting members older than 14 days is not allowed.\n contact administrator if it's necessary", "Delete", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var message = "Confirm editing member's information: ID[" + member.ID + "],\nName: " + member.FirstName + " " + member.LastName + " \n Subscription: " + member.MembershipName;
            if (ShowConfirmationWindow(message, "Deleting a book"))
            {
                var wasSuccesful = Container.UnitOfWork.MemberRepository.Delete(int.Parse(txtMemberID.Text));
                StatusQuerySuccess(wasSuccesful);
            }
        }
        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            if (Container.MembershipList == null)
            {
                Container.MembershipList =
                    Container.UnitOfWork.MembershipRepository.GetAll(MembershipParser.Instance.MakeMembershipResult);
            }
            var signform = new SignUpForm();
            signform.Owner = Application.Current.MainWindow;
            signform.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (signform.ShowDialog() == true)
            {
                var member = signform.GetMember();
                var wasSuccesful = Container.UnitOfWork.MemberRepository.Add(member);
                StatusQuerySuccess(wasSuccesful);
            }
        }        
        private void btnMemberRenew_Click(object sender, RoutedEventArgs e)
        {
            if (!txtMemberID.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please select a member", "Selection failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var id = int.Parse(txtMemberID.Text);
            var renewWindow = new RenewConfirmationWindow(Container.MemberList.First(x => x.ID == id));
            renewWindow.Owner = Application.Current.MainWindow;
            renewWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (renewWindow.ShowDialog() == true)
            {
                var wasSuccesful = Container.UnitOfWork.MemberRepository.Renew(id, renewWindow.GetSelectedMembership());
                StatusQuerySuccess(wasSuccesful);
            }
        }
        private void btnClearMember_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
        }
        private void btnMemberRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadMemberTable();
            dataGridMain.ItemsSource = Container.MemberList;
        }
        private void comboBoxMemberGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxMemberGender.SelectedIndex == -1)
            {
                comboBoxMemberGender.SelectedIndex = 0;
            }
        }
        #endregion MemberForms

        #region BorrowForms
        private void btnBorrowRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadBookTable();
            LoadMemberTable();
            LoadBorrowTable();
            dataGridMain.ItemsSource = Container.BorrowList;
            DataContext = null;
        }
        private void txtBorrowBookID_TextChanged(object sender, TextChangedEventArgs e)
        {
            int bookId;
            if (!int.TryParse(txtBorrowBookID.Text, out bookId)) return;
            var book = Container.BookList.FirstOrDefault(b => b.ID == bookId);
            if (book != null)
            {
                tblockBookSummary.Text = " '" + book.Name + "' by " + book.Author + ".\n " + book.Gendre + 
                                         " book published in " + book.Year + ". \n Books left: " + book.Amount;
            }
            else
            {
                tblockBookSummary.ClearValue(TextBlock.TextProperty);
            }
        }
        private void txtBorrowMemberID_TextChanged(object sender, TextChangedEventArgs e)
        {
            int memberId;
            if (!int.TryParse(txtBorrowMemberID.Text, out memberId)) return;
            var member = Container.MemberList.FirstOrDefault(m => m.ID == memberId);
            if (member != null)
            {
                tblockMemberSummary.Text = member.FirstName + " " + member.LastName + ", " + member.MembershipName + ".\n "+
                                           "Member since " + member.JoinDate + " \n Currently has " + member.CurrentBooks + 
                                           " library's books.";
            }
            else
            {
                tblockMemberSummary.ClearValue(TextBlock.TextProperty);
            }
        }
        private void btnBorrowLend_Click(object sender, RoutedEventArgs e)
        {
            if (!IsGridValid(gridBorrow))
            {
                ShowValidationError();
                return;
            }
            var memberId = int.Parse(txtBorrowMemberID.Text);
            var bookId = int.Parse(txtBorrowBookID.Text);
            var book = Container.BookList.FirstOrDefault(b => b.ID == bookId);
            var member = Container.MemberList.FirstOrDefault(m => m.ID == memberId);
            if (book == null || member == null)
            {
                MessageBox.Show("Member's or book's ID you've entered is Invalid.\nPlease revisit ID's or refresh database",
                    "Invalid field values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var membership = Container.MembershipList.FirstOrDefault(mt => mt.Name == member.MembershipName);
            if (Convert.ToDateTime(member.SubscriptionStartDate).AddMonths(membership.MonthPlan) <= DateTime.Now)
            {
                MessageBox.Show(member.FirstName + " " + member.LastName + "' subscription ran out!\n" + 
                    "Only members with active membership can lend a book","Expired Membership", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(member.CurrentBooks >= membership.MaxbookAmount)
            {
                MessageBox.Show(member.FirstName + " " + member.LastName + " reached book limit!\n" +
                    "Member must return any borrowed book before taking another one.", "Book limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var overdueBook = (from b in Container.BorrowList.Where(bl => bl.MemberID == memberId)
                where Convert.ToDateTime((b.LendDate)).AddDays(membership.OverdueDayLimit) <= DateTime.Now
                select b).ToList();
            if (overdueBook.Any())
            {
                var overdueBookDetails = new StringBuilder();
                foreach (var bookDetail in overdueBook)
                {
                    overdueBookDetails.Append("[" + bookDetail.BookID + "] " + bookDetail.Title + ".\n");
                }
                MessageBox.Show(member.FirstName + " " + member.LastName + "' has an overdue book(s)!\n" +
                                "Member must return one of these books before taking new one:\n" + overdueBookDetails, 
                                "Book limit reached", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ShowConfirmationWindow("Confrim lending a book.", "Lending a book"))
            {
                var wasSuccesful = Container.UnitOfWork.BorrowRepository.Lend(memberId, bookId, Container.CurrentUserId);
                StatusQuerySuccess(wasSuccesful);
            }
        }
        private void btnBorrowReturn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsGridValid(gridBorrow))
            {
                ShowValidationError();
                return;
            }               
            var memberId = int.Parse(txtBorrowMemberID.Text);
            var bookId = int.Parse(txtBorrowBookID.Text);
            var member = Container.MemberList.FirstOrDefault(x => x.ID == memberId);
            if (member == null && Container.BookList.Any(x => x.ID == bookId))
            {
                MessageBox.Show("Member's or book's ID you've entered is Invalid.\nPlease revisit ID's or refresh database",
                         "Invalid field values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var borrowed = (from b in Container.BorrowList
                            where b.BookID == bookId && b.MemberID == memberId
                            select b).FirstOrDefault();
            if (borrowed == null)
            {
                MessageBox.Show("Member doens't owe us such book.\nPlease revisit ID's and refresh database",
                    "Invalid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var membership = Container.MembershipList.FirstOrDefault(x => x.Name == member.MembershipName);
            var daysTaken = (int)Math.Round((DateTime.Now - Convert.ToDateTime(borrowed.LendDate)).TotalDays);
            if (daysTaken >= membership.OverdueDayLimit)
            {
                var price = membership.OverdueFees*daysTaken;
                price = price >= 10 ? 10 : price;
                MessageBox.Show("This book is overdue!.\nMember must pay: " + price.ToString("C", new CultureInfo("en-US")) +
                    "\nBefore taking a new book.","Invalid values", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ShowConfirmationWindow("Confrim returning a book", "Returning a book"))
            {
                int result = Container.UnitOfWork.BorrowRepository.Return(memberId, bookId);
                StatusQuerySuccess(result);
            }
                
        }
        #endregion BorrowForms

        #region Helpers
        private void StatusTimeElapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                lblStatus.ClearValue(ContentProperty);
                lblStatus.ClearValue(BorderBrushProperty);
            });
        }
        private void StatusQuerySuccess(int rowsAffected, string success = "Action succeeded!", string failure = "Action Failed")
        {
            if (rowsAffected > 0)
            {
                lblStatus.Content = success;
                lblStatus.Foreground = Brushes.Green;
            }
            else
            {
                MessageBox.Show("Action failed even thought it passed validation.\n" +
                            "Please refresh database and revisit your input.", "Refresh database", MessageBoxButton.OK, MessageBoxImage.Warning);
                lblStatus.Content = failure;
                lblStatus.Foreground = Brushes.Red;
            }
        }
        private void SwitchToGrid(Grid grid)
        {
            gridBook.IsEnabled = false;
            gridMember.IsEnabled = false;
            gridBorrow.IsEnabled = false;

            gridBook.Visibility = Visibility.Collapsed;
            gridMember.Visibility = Visibility.Collapsed;
            gridBorrow.Visibility = Visibility.Collapsed;

            grid.IsEnabled = true;
            grid.Visibility = Visibility.Visible;
        }
        private void FillSearchList(Type type)
        {
            comboBoxCategory.Items.Clear();
            var constructor = type.GetConstructor(Type.EmptyTypes);
            if (constructor != null)
            {
                var entity = constructor.Invoke(new object[] { }).GetType().GetProperties();
                foreach (var category in entity)
                {
                    comboBoxCategory.Items.Add(category.Name);
                }
            }
        }
        public static bool IsGridValid(DependencyObject grid)
        {
            return !Validation.GetHasError(grid) &&
                    LogicalTreeHelper.GetChildren(grid)
                    .OfType<DependencyObject>()
                    .All(IsGridValid);
        }
        private void LoadBookTable()
        {
            Container.BookList = Container.UnitOfWork.BookRepository.GetAll(BookParser.Instance.MakeBookResult);
            Container.BookLocationList = Container.UnitOfWork.BookLocationRepository.GetAll(BookLocationParser.Instance.MakeBookLocationResult).ToList();
            comboBoxBookFloor.ItemsSource = (from floor in Container.BookLocationList
                                             select floor.Floor).Distinct();
            comboBoxBookShelf.ItemsSource = (from list in Container.BookLocationList
                                             select list.Shelf).Distinct();
            FillSearchList(typeof(BookEntity));
        }
        private void LoadMemberTable()
        {
            Container.MemberList = Container.UnitOfWork.MemberRepository.GetAll(MemberParser.Instance.MakeMemberResult);
            Container.MembershipList = Container.UnitOfWork.MembershipRepository.GetAll(MembershipParser.Instance.MakeMembershipResult);
            comboBoxMembershipName.ItemsSource = (from type in Container.MembershipList
                                                  select type.Name).Distinct();
            FillSearchList(typeof(MemberEntity));
        }
        private void LoadBorrowTable()
        {
            Container.BorrowList = Container.UnitOfWork.BorrowRepository.GetAll(BorrowParser.Instance.MakeBorrowResult);
            FillSearchList(typeof(BorrowModel));
        }
        private void ShowValidationError()
        {
            MessageBox.Show("All fields must be valid and not empty!", "Invalid field values", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private bool ShowConfirmationWindow(string message, string windowName)
        {
            var messageBoxResult = MessageBox.Show(message, windowName, MessageBoxButton.YesNo);
            return messageBoxResult == MessageBoxResult.Yes;
        }

        #endregion Helpers

        #region Semi-Hotkeys
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearch.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
        private void gridBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    btnBookAdd.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                else
                    btnBookEdit.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
        private void gridMember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    btnMemberRenew.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                else
                    btnMemberEdit.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
        private void gridBorrow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    btnBorrowReturn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                else
                    btnBorrowLend.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        #endregion Semi-Hotkeys

       
    }
}

