using BalotoRandom.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalotoRandom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();
            BindingContext = new ResultViewModel();
            Shell.SetTabBarIsVisible(this, false);
        }
    }
}