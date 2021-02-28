using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));

            //GetLocation = new Command(async () =>
            //{
            //    await ;
            //});
        }

        

        public ICommand OpenWebCommand { get; }
        public ICommand GetLocation { get; }
        
    }
}