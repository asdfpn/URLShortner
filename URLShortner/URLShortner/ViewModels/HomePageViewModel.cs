using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using URLShortner.Models;
using URLShortner.Services;
using URLShortner.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace URLShortner.ViewModels
{
	public class HomePageViewModel : INotifyPropertyChanged
    {
        private string longURL;
        private string shortURL;

        public string LongURL
        {
            get => longURL;
            set
            {
                if(longURL != value) { longURL = value; }

                OnPropertyChanged(nameof(LongURL));
            }
        }

        public string ShortURL
        {
            get => shortURL;
            set
            {
                if (shortURL != value) { shortURL = value; }

                OnPropertyChanged(nameof(ShortURL));
            }
        }

        public ICommand SubmitButtonClick { get; set; }
        public ICommand OpenURLClick { get; set; }
        public ICommand ArchievedURLsClick { get; set; }

        public HomePageViewModel()
		{
            SubmitButtonClick = new Command(async () => await OnSubmitButtonClick());
            OpenURLClick = new Command<string>(async (x) => await OnOpenURLClick(x));
            ArchievedURLsClick = new Command(async () => await OnArchievedURLsClick());
        }

        private async Task OnSubmitButtonClick()
        {
            var request = new ShortnerRequestResponse()
            {
                long_url = LongURL
            };

            var response = await HttpClientService.Instance.PostAsync<ShortnerRequestResponse>(request);
            ShortURL = response.short_url;

            var uRL = new URL
            {
                hash = response.hash,
                long_url = response.long_url,
                short_url = response.short_url
            };

            await URLStorageService.AddURL(uRL);
        }

        private async Task OnOpenURLClick(string shortURL)
        {
            await Browser.OpenAsync(new Uri(shortURL), BrowserLaunchMode.SystemPreferred);
        }

        private async Task OnArchievedURLsClick()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HistoryPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

