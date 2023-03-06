using System;
using URLShortner.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace URLShortner
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

