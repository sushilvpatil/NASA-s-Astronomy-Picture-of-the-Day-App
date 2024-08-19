using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace NasaImages.ViewModel
{
    public class ViewImageFullScreenModel : INotifyPropertyChanged
    {

        public ViewImageFullScreenModel(string url)
        {
            Url = url;
        }

        private string _Url;
        public string Url
        {
            get => _Url;
            set
            {
                _Url = value;
                OnPropertyChanged();
            }
        }


        public Command GoBack
        {
            get
            {
                return new Command(() =>
                {
                    Application.Current.MainPage.Navigation.PopAsync();
                });
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
