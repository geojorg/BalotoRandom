using BalotoRandom.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalotoRandom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RevanchaPage : ContentPage
    {
        public RevanchaPage()
        {
            InitializeComponent();
            BindingContext = new RevanchaViewModel();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}