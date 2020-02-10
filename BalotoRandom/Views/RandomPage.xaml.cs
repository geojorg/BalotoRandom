using BalotoRandom.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalotoRandom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomPage : ContentPage
    {
        public RandomPage()
        {
            InitializeComponent();
            BindingContext = new RandomViewModel();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}