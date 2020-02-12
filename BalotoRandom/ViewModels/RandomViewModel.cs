using BalotoRandom.Helpers;
using BalotoRandom.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BalotoRandom.ViewModels
{
    public class RandomViewModel : BaseViewModel
    {
        private int num1;
        private int num2;
        private int num3;
        private int num4;
        private int num5;
        private int num6;
        private bool isVisible;
        private string color;
        private string _message;
        private readonly APIService.RestService restService;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public RandomViewModel()
        {
            IsVisible = false;
            Color = "Transparent";
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.InternetError, Languages.Accept);
            }
            else
            {
                restService = new APIService.RestService();
                var Data = restService.GetBalotoResultsAsync();
            }
        }

        public ICommand GenerateCommand => new Command(Generate);
        private async void Generate()
        {
            Message = Languages.Message;
            var analyticsService = DependencyService.Get<IFirebaseAnalytics>();
            analyticsService.LogEvent("aleatorio");
            Color = "Black";
            IsVisible = true;
            Random rand = new Random();
            Random random = new Random();
            List<int> numbers = new List<int>();
            while (numbers.Count < 5)
            {
                int rnd = random.Next(1, 44);
                if (!numbers.Contains(rnd)) numbers.Add(rnd);
            }

            int delay = 5;
            {
                await Task.Delay(delay);
                Num1 = numbers[0];
                delay = delay * 2;
                await Task.Delay(delay);
                Num2 = numbers[1];
                delay = delay * 2;
                await Task.Delay(delay);
                Num3 = numbers[2];
                delay = delay * 2;
                await Task.Delay(delay);
                Num4 = numbers[3];
                delay = delay * 2;
                await Task.Delay(delay);
                Num5 = numbers[4];
                delay = delay * 2;
                await Task.Delay(delay);
                Num6 = rand.Next(1, 17);
            }
        }

        public ICommand ArtificialCommand => new Command(Artificial);
        private async void Artificial()
        {
            Message = Languages.MessageProb;
            DependencyService.Get<IAdInterstitial>().ShowAd();
            var analyticsService = DependencyService.Get<IFirebaseAnalytics>();
            analyticsService.LogEvent("probable");
            Color = "Black";
            IsVisible = true;
            Random rand = new Random();
            Random random = new Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 5)
            {
                int rnd = random.Next(1, 44);
                if (!numbers.Contains(rnd)) numbers.Add(rnd);
            }

            int delay = 5;
            {
                var artinumbers = numbers.ToArray();
                Array.Sort(artinumbers);
                await Task.Delay(delay);
                Num1 = artinumbers[0];
                delay = delay * 2;
                await Task.Delay(delay);
                Num2 = artinumbers[1];
                delay = delay * 2;
                await Task.Delay(delay);
                Num3 = artinumbers[2];
                delay = delay * 2;
                await Task.Delay(delay);
                Num4 = artinumbers[3];
                delay = delay * 2;
                await Task.Delay(delay);
                Num5 = artinumbers[4];
                delay = delay * 2;
                await Task.Delay(delay);
                Num6 = rand.Next(1, 17);
            }
        }

        public string Color
        {
            get { return color; }
            set { SetProperty(ref color, value); }
        }
        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }
        public int Num1
        {
            get { return num1; }
            set { SetProperty(ref num1, value); }
        }
        public int Num2
        {
            get { return num2; }
            set { SetProperty(ref num2, value); }
        }
        public int Num3
        {
            get { return num3; }
            set { SetProperty(ref num3, value); }
        }
        public int Num4
        {
            get { return num4; }
            set { SetProperty(ref num4, value); }
        }
        public int Num5
        {
            get { return num5; }
            set { SetProperty(ref num5, value); }
        }
        public int Num6
        {
            get { return num6; }
            set { SetProperty(ref num6, value); }
        }
    }
}
