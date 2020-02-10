using BalotoRandom.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalotoRandom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {

        public LocationPage()
        {
            InitializeComponent();
            BindingContext = new LocationViewModel();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}

