using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        public async void LocationCommandClicked(object sender, EventArgs e)
        {
            //var location;
            var location = await Geolocation.GetLocationAsync();
            string labelLoc = string.Format("Long: {0}, Lat: {1}", location.Longitude, location.Latitude);
            LocationLabel.Text = labelLoc;
            //m_locationLabel = labelLoc;
        }

        public string m_locationLabel;
    }
}