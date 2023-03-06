using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using URLShortner.Models;
using URLShortner.Services;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace URLShortner.ViewModels
{
	public class HistoryPageViewModel : INotifyPropertyChanged
    {

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value) { isBusy = value; }
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private ObservableCollection<URL> archivedURLs;

        public ObservableCollection<URL> ArchivedURLs
        {
            get
            {
                return (archivedURLs == null) ? archivedURLs = new ObservableCollection<URL>() : archivedURLs;
            }
            set
            {
                if (archivedURLs != value) { archivedURLs = value; }
                OnPropertyChanged(nameof(ArchivedURLs));
            }
        }


        public ICommand RefreshCommand { get; set; }

        public HistoryPageViewModel()
		{
            RefreshCommand = new Command(async () => await OnListRefresh());
            ArchivedURLs = new ObservableCollection<URL>();
        }

        private async Task OnListRefresh()
        {
            IsBusy = true;

            await Task.Delay(500);

            ArchivedURLs.Clear();
            
            var uRLs = await URLStorageService.GetURL();
            uRLs.Reverse();

            foreach (URL url in uRLs)
            {
                ArchivedURLs.Add(url);
            }

            IsBusy = false;
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

