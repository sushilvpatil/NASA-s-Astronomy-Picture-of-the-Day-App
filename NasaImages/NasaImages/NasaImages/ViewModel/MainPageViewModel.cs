using NasaImages.Model;
using NasaImages.Services;
using NasaImages.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NasaImages.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged

    {

        public IApodService _nasaApiService;

        public MainPageViewModel()
        {
            _nasaApiService = DependencyService.Get<IApodService>();
        }

        private ApodResponse _apodData;
        public ApodResponse ApodData
        {
            get => _apodData;
            set
            {
                _apodData = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _IsImageVisible;
        public bool IsImageVisible
        {
            get => _IsImageVisible;
            set
            {
                _IsImageVisible = value;
                OnPropertyChanged();
            }
        }


        private bool _ErrorMessageVisible;
        public bool ErrorMessageVisible
        {
            get => _ErrorMessageVisible;
            set
            {
                _ErrorMessageVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _IsWatchVideoButtonVisible;
        public bool IsWatchVideoButtonVisible
        {
            get => _IsWatchVideoButtonVisible;
            set
            {
                _IsWatchVideoButtonVisible = value;
                OnPropertyChanged();
            }
        }

        public Command ShowFullScreentImage
        {
            get
            {
                return new Command<String>(async (Data) =>
                {
                    if (!string.IsNullOrEmpty(Data))
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewImageFullScreen(Data));
                });
            }
        }

        public Command WatchVideoCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new WatchVideo());
                });
            }
        }
        public Command ReloadImageCommand
        {
            get
            {
                return new Command(async () =>
                {
                    GetImage();
                });
            }
        }


        public async void GetImage()
        {
            try
            {
                IsLoading = true;
                ErrorMessage = null;
                bool isConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
                if (isConnected)
                {

                    var response = await _nasaApiService.GetAposAsync<ApodResponse>();
                    if (response != null)
                    {

                        if (IsImageUrl(response.Url))
                        {
                            ApodData = response;
                            IsImageVisible = true;
                            ErrorMessageVisible = false;
                            IsWatchVideoButtonVisible = false;
                        }
                        else
                        {
                            ApodData = response;
                            IsImageVisible = false;
                            ErrorMessage = "Image Is Not Available";
                            ErrorMessageVisible = true;
                            IsWatchVideoButtonVisible = true;
                        }

                    }
                    else
                    {
                        ErrorMessage = "Image Is Not Available";
                        ErrorMessageVisible = true;
                        IsWatchVideoButtonVisible = true;
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Internet", "Internet Required", "Cancel");
                    ErrorMessage = "Image Is Not Available";
                    ErrorMessageVisible = true;
                }
            }
            catch (Exception ex)
            {

                ErrorMessage = "Image Is Not Available";
                ErrorMessageVisible = true;
                IsWatchVideoButtonVisible = true;
            }
            IsLoading = false;
        }


        public static bool IsImageUrl(string url)
        {
            var imageExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            return imageExtensions.Any(ext => url.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
