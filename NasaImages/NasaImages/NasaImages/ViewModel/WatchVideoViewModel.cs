using NasaImages.Model;
using NasaImages.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace NasaImages.ViewModel
{
    public class WatchVideoViewModel : INotifyPropertyChanged
    {


        public WatchVideoViewModel()
        {
            _nasaApiService = DependencyService.Get<IApodService>();
        }


        private readonly IApodService _nasaApiService;

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



        private bool _IsVideoVisible;
        public bool IsVideoVisible
        {
            get => _IsVideoVisible;
            set
            {
                _IsVideoVisible = value;
                OnPropertyChanged();
            }
        }


        public async void GetVideo()
        {
            try
            {
                IsLoading = true;

                var response = await _nasaApiService.GetAposAsync<ApodResponse>();
                if (response != null)
                {

                    ApodData = response;
                    if (!IsImageUrl(response.Url))
                        IsVideoVisible = true;
                    else
                    {
                        IsVideoVisible = false;
                        ErrorMessageVisible = true;
                    }

                }
                else
                {
                    IsVideoVisible = false;
                    ErrorMessageVisible = true;
                }
            }
            catch (Exception ex)
            {

                IsVideoVisible = false;
                ErrorMessageVisible = true;
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
