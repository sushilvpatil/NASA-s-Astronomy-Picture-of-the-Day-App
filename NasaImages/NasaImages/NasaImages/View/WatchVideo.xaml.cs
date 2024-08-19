using NasaImages.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace NasaImages.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchVideo : ContentPage
    {
        public WatchVideo()
        {
            InitializeComponent();
            var viewModel = new WatchVideoViewModel();
            this.BindingContext = viewModel;
            bool isConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
            if (isConnected)
                viewModel.GetVideo();
            else
            {
                Application.Current.MainPage.DisplayAlert("Internet", "Internet Required", "Cancel");
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}