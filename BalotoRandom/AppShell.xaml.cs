using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BalotoRandom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public ICommand RateCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public ICommand ShareAppCommand => new Command(ShareApp);
        private async void ShareApp()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "Compartir App",
                Uri = "https://play.google.com/store/apps/details?id=com.companyname.balotorandom"
            });
        }

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}