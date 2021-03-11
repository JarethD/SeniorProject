using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Database_Helpers;
using Core.Classes;
using Core.Interfaces;
using CommonServiceLocator;
using Microsoft.Maps.MapControl.WPF;
using Messaging;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserData databaseAccess;
        SqlServerDataAccess dbac2;
        public Login()
        {
            InitializeComponent();
            dbac2 = new SqlServerDataAccess();
            databaseAccess = new UserData(dbac2);
            AccountTypeBox.Items.Add("Lumber Company");
            AccountTypeBox.Items.Add("Hardware Store");
            AccountTypeBox.Items.Add("Truck Driver");
            AccountTypeBox.Items.Add("Lumber Associate");

        }

        private void AccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {

            string password = PasswordBox.Password;
            string HashPass = BCryptHash.HashPassword(password);
            long phoneNum = Int64.Parse(PhoneNumberBox.Text);

            if (AccountTypeBox.SelectedItem.Equals("Lumber Associate"))
            {
                long id = databaseAccess.GetRecentEmployeeID();

                LumberAssociate newLA = new LumberAssociate(UsernameBox.Text, HashPass, NameBox.Text, id, phoneNum, AddressBox.Text, 0);
                databaseAccess.AddLumberAssociate(newLA);
            }
            else if (AccountTypeBox.SelectedItem.Equals("TruckDriver"))
            {
                long id = databaseAccess.GetRecentEmployeeID();

                TruckDriver newDriver = new TruckDriver(UsernameBox.Text, HashPass, NameBox.Text, id, phoneNum, AddressBox.Text, 0);
                databaseAccess.AddTruckDriver(newDriver);
            }
            else if (AccountTypeBox.SelectedItem.Equals("Lumber Company"))
            {
                long id = databaseAccess.GetRecentCompanyID();

                LumberCompany newLC = new LumberCompany(UsernameBox.Text, HashPass, id, CompanyBox.Text, AddressBox.Text, phoneNum);
                databaseAccess.AddLumberCompany(newLC);
            }
            else if (AccountTypeBox.SelectedItem.Equals("Hardware Store"))
            {
                long id = databaseAccess.GetRecentCompanyID();
                HardwareStore newHS = new HardwareStore(UsernameBox.Text, HashPass, id, CompanyBox.Text, AddressBox.Text, phoneNum);
                databaseAccess.AddHardwareStore(newHS);
            }
        }
    }
}
