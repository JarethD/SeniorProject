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
        //iSqlServerDataAccess databaseAccess;
        //iUserData databaseAcc;
        //iSqlServerDataAccess dataAccess;
        UserData databaseAccess;
        iSqlServerDataAccess dbac;
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
        }

        private void AddLumberassociate_Click(object sender, RoutedEventArgs e)
        {
            LumberAssociate associate = new LumberAssociate("jarethDods", " ", "jd", 6655998844, "Brookings Or", "Ace Hardware");
            //Check Username, if username is not in database, then add truckdriver 
            //return true is successfull
            //return false is unsuccessfull
            databaseAccess.AddLumberAssociate(associate);
        }

        private void AddTruckdriver_Click(object sender, RoutedEventArgs e)
        {
            TruckDriver driver = new TruckDriver("jarethdod", " ", "Jareth Dodson", 5557778899, "Arthur St.", "Brookings Lumber");
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
    }
}
