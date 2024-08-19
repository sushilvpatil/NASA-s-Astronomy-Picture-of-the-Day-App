using NasaImages.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
namespace NasaImages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel = new MainPageViewModel();
            this.BindingContext = viewModel;
          
           
                viewModel.GetImage();
            
           
        }


    }
}
