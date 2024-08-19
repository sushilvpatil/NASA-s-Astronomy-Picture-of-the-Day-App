using NasaImages.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NasaImages.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewImageFullScreen : ContentPage
    {
        public ViewImageFullScreen( string url)
        {
            InitializeComponent();
            BindingContext = new ViewImageFullScreenModel(url);
        }
    }
}