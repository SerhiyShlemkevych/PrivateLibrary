using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using EpamTask.PrivateLibrary.Entity.Member;
using EpamTask.PrivateLibrary.Global;

namespace EpamTask.PrivateLibrary
{
    /// <summary>
    /// Interaction logic for RenewConfirmationWindow.xaml
    /// </summary>
    public partial class RenewConfirmationWindow 
    {
        public RenewConfirmationWindow(MemberEntity member)
        {
            InitializeComponent();
            DataContext = member;
            comboBoxMembership.ItemsSource = from type in Container.MembershipList
                                              select type.Name;
            comboBoxMembership.SelectedValue = member.MembershipName;
            tblockStart.Text = DateTime.Now.ToString("dd/MM/yyyy");
  
        }
        public string GetSelectedMembership()
        {
            return comboBoxMembership.SelectedItem.ToString();
        }
        private void comboBoxMembership_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var membershipDetails = (from type in Container.MembershipList
                                     where type.Name == comboBoxMembership.SelectedItem.ToString()
                                     select new { months = type.MonthPlan, price = type.PricePerMonth }).First();
            tblockEnd.Text = DateTime.Now.AddMonths(membershipDetails.months).ToString("dd/MM/yyyy");
            tblockPrice.Text = (membershipDetails.months * membershipDetails.price).ToString("C", new CultureInfo("en-US"));
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void gridRenew_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    btnConfirm.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
                case Key.Escape:
                    btnCancel.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    break;
            }
        }
    }
}
