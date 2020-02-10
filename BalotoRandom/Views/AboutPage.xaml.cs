using BalotoRandom.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalotoRandom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}