using System;
using System.Collections.Generic;
using URLShortner.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace URLShortner.Views
{	
	public partial class HistoryPage : ContentPage
	{	
		public HistoryPage ()
		{
			InitializeComponent ();
            On<iOS>().SetUseSafeArea(true);
            BindingContext = new HistoryPageViewModel();
        }
	}
}

