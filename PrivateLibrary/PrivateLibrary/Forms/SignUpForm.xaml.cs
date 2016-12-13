using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Global;

namespace EpamTask.PrivateLibrary
{
    /// <summary>
    /// Interaction logic for SignUpForm.xaml
    /// </summary>
    public partial class SignUpForm
    {
        public SignUpForm()
        {
            DataContext = new MemberEntity();
            InitializeComponent();
            comboBoxMemberGender.Items.Add("Male");
            comboBoxMemberGender.Items.Add("Female");
            var membershipList = Container.MembershipList.ToList();
            comboBoxMembershipName.ItemsSource = (from type in membershipList
                                                  select type.Name).Distinct();
            ShowMembershipDetails(membershipList,gridMembershipDetails);
        }


        public MemberEntity GetMember()
        {
            var member = (MemberEntity) DataContext;
            return member;
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.IsGridValid(gridSignUp))
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("All fields must be valid and not empty!", "Invalid field values", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private void ShowMembershipDetails(List<MembershipEntity> list, Grid grid)
        {
            for (var index = 0; index < list.Count; index++)
            {
                var column = index + 1;
                if (column > grid.ColumnDefinitions.Count)
                {
                    break;
                }
                var row = 0;
                AddHeader(list[index].Name, row++, column);
                // Review IP: use string format or string interpolation
                AddLabel(list[index].MaxbookAmount + " books", row++, column);
                AddLabel(list[index].MonthPlan + " months", row++, column);
                AddLabel(list[index].PricePerMonth.ToString("C", new CultureInfo("en-US")), row++, column);
                AddLabel((list[index].MonthPlan * list[index].PricePerMonth).ToString("C", new CultureInfo("en-US")), row++, column);
                AddLabel(list[index].OverdueDayLimit + " days", row++, column);
                AddLabel(list[index].OverdueFees.ToString("C", new CultureInfo("en-US")), row, column);
            }
        }
        private void AddHeader(string text, int row, int column)
        {
            var txt = new TextBlock
            {
                Width = 90,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Text = text,
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold,
                FontSize = 14
            };
            Grid.SetRow(txt, row);
            Grid.SetColumn(txt, column);
            gridMembershipDetails.Children.Add(txt);
        }
        private void AddLabel(string text, int row, int column)
        {
            var txt = new Label()
            {
                Width = 100,
                Height = 28,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = text,
                FontFamily = new FontFamily("Segoe UI"),
                Foreground = Brushes.Black
            };
            Grid.SetRow(txt, row);
            Grid.SetColumn(txt, column);
            gridMembershipDetails.Children.Add(txt);
        }
    }
}
