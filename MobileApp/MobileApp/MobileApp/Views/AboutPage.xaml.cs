using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sql_database;

namespace MobileApp.Views
{
    public partial class AboutPage : ContentPage
    {
        UserAccess databaseAccess;
        DBAccess dba;// = new DBAccess();
        public AboutPage()
        {
            InitializeComponent();
            dba = new Sql_database.DBAccess();
            databaseAccess = new UserAccess(dba);
        }

        public async void LocationCommandClicked(object sender, EventArgs e)
        { 
            var location = await Geolocation.GetLocationAsync();
            string labelLoc = string.Format("Long: {0}, Lat: {1}", location.Longitude, location.Latitude);
            LocationLabel.Text = labelLoc;
        }

        public async void SendLocation_Clicked(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLocationAsync();
            string labelLoc = string.Format("Long: {0}, Lat: {1}", location.Longitude, location.Latitude);
            LocationLabel.Text = labelLoc;
            databaseAccess.SetLatAndLong(2, location.Longitude, location.Latitude);
        }

        public string m_locationLabel;
    }
}