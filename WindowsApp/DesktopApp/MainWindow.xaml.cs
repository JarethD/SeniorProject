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

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserData databaseAccess;
        SqlServerDataAccess dbac2;
        public MainWindow()
        {
            InitializeComponent();
            //HardwareStore lumberCompany = new HardwareStore("AceHardwareBKOR", "", "Ace Hardware", "Brookings Oregon", 5416619764, 01, 01);
            //LumberAssociate lumberPerson = new LumberAssociate("JarethDodson", "", 01, "Jareth Dodson", 5415554444, "Ace Hardware", 01);
            //lumberCompany.AddLA(lumberPerson);
            // = new iSqlServerDataAccess();   
            //databaseAcc = new UserData();
            dbac2 = new SqlServerDataAccess();
            databaseAccess = new UserData(dbac2);
            IdentifierBox.Items.Add("Lumber Associate");
            IdentifierBox.Items.Add("Hardware Store");
            IdentifierBox.Items.Add("Lumber Company");
            IdentifierBox.Items.Add("Truck Driver");
        }

        private void AddLumberassociate_Click(object sender, RoutedEventArgs e)
        {
            LumberAssociate associate = new LumberAssociate("raulg", " ", "Raul Gonzalez", 0, 1234567891, "Arthur St.", 1);
            //Check Username, if username is not in database, then add truckdriver 
            //return true is successfull
            //return false is unsuccessfull
            databaseAccess.AddLumberAssociate(associate);
        }

        private void AddTruckdriver_Click(object sender, RoutedEventArgs e)
        {
            string password = TruckDriverPassword.Password;
            string HashPass = BCryptHash.HashPassword(password);

            TruckDriver driver = new TruckDriver("jjjj", HashPass, "Raul Gonzalez", 1234567891, "Arthur St.", 2);
            //Check Username, if username is not in database, then add truckdriver 
            //return true is successfull
            //return false is unsuccessfull
            databaseAccess.AddTruckDriver(driver);
        }

        private void AddLumbercompany_Click(object sender, RoutedEventArgs e)
        {
            LumberCompany company = new LumberCompany("BrookLumb", " ", "Brookings Lumber", "Arthur St", 3334445566);
            databaseAccess.AddLumberCompany(company);
        }

        private void AddHardwarestore_Click(object sender, RoutedEventArgs e)
        {
            HardwareStore store = new HardwareStore("BrookAce", " ", "Ace Hardware", "327 Checto Rd.", 0099887766);
            databaseAccess.AddHardwareStore(store);
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order("Order 1", "12 - 2x4x6 / 6 - 4x4x8", "Crescent City Lumber", "Cascade HC", status.PROGRESS, priority.MEDIUM);
            databaseAccess.AddOrder(order);
        }

        private void DeleteHardwareStore_Click(object sender, RoutedEventArgs e)
        {
            //HardwareStore store = new HardwareStore("BrookAce", " ", "Ace Hardware", "327 Checto Rd.", 0099887766);
            long id = databaseAccess.GetRecentCompanyID();
            databaseAccess.DeleteHardwareStore(id);
        }

        private void DeleteLumberAssociate_Click(object sender, RoutedEventArgs e)
        {
            long id = databaseAccess.GetRecentEmployeeID();
            databaseAccess.DeleteLumberAssociate(id);
        }

        private void DeleteLumberCompany_Click(object sender, RoutedEventArgs e)
        {
            long id = databaseAccess.GetRecentCompanyID();
            databaseAccess.DeleteLumberAssociate(id);
        }

        private void DeleteTruckDriver_Click(object sender, RoutedEventArgs e)
        {
            long id = databaseAccess.GetRecentEmployeeID();
            databaseAccess.DeleteTruckDriver(id);
        }

        private void GetLumberCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            String usernameBox = CompUsernameBox.Text;
            if (usernameBox != "")
            {
                LumberCompany company = new LumberCompany(databaseAccess.GetLumberCompany(usernameBox));
                if(company.username != null)
                {
                    CompUsernameText.Text = company.username;
                }
                else
                {
                    CompUsernameText.Text = "Not found";
                }
            }
        }

        private void GetOrder_Click(object sender, RoutedEventArgs e)
        {
            List<Order> DisplayList = new List<Order>();
            //String driveridstring = GetOrderBox.Text;
            //int driverid = Int32.Parse(driveridstring);
            //DisplayList = databaseAccess.GetOrders(driverid);
            //OrderBlock.Text = String.Format("{0}", DisplayList.Count());
            String Locationto = GetOrderBox.Text;
            DisplayList = databaseAccess.GetOrders(Locationto);

            OrderList.ItemsSource = DisplayList;
        }

        private void submitPass_Click(object sender, RoutedEventArgs e)
        {
            String password = isPasswordBox.Text;
            String Username = UsernameBox.Text;
            HardwareStore store;
            LumberAssociate associate;
            LumberCompany company;
           // TruckDriver driver;
            if (IdentifierBox.SelectedItem.Equals("Hardware Store"))
                store = (databaseAccess.GetHardwareStore(Username));
            else if (IdentifierBox.SelectedItem.Equals("Lumber Associate"))
                associate = (databaseAccess.GetLumberAssociate(Username));
            else if (IdentifierBox.SelectedItem.Equals("Lumber Company"))
                company = (databaseAccess.GetLumberCompany(Username));
            else if (IdentifierBox.SelectedItem.Equals("Truck Driver"))
            {
                TruckDriver driver = new TruckDriver(databaseAccess.GetTruckDriver(Username));
                if (BCryptHash.ValidatePassword(password, driver.HashPass))
                {
                    IsPasswordBlock.Text = "True";
                }
                else
                    IsPasswordBlock.Text = "False";
            }// Get Password with current username
            // Add username box for gui for testing 
            // Delete all users for just a single user with a password or add gui to add all elements 
            // or at least a username

            //databaseAccess.GetHardwareStore(Username);
            //String hashpass =
            //if (BCryptHash.ValidatePassword(password, driver.HashPass ))
            //{
            //    IsPasswordBlock.Text = "True";
            //}
            //else
            //    IsPasswordBlock.Text = "False";
        }
    }
}
