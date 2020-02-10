using BalotoRandom.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalotoRandom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BalotoPage : ContentPage
    {
        public BalotoPage()
        {
            InitializeComponent();
            BindingContext = new BalotoViewModel();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}