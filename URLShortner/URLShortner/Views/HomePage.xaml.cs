using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortner.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace URLShortner.Views
{	
	public partial class HomePage : ContentPage
	{	
		public HomePage ()
		{
			InitializeComponent ();
            On<iOS>().SetUseSafeArea(true);
            BindingContext = new HomePageViewModel();
        }
	}
}

