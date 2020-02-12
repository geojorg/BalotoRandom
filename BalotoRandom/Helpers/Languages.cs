using BalotoRandom.Interfaces;
using BalotoRandom.Resources;
using Xamarin.Forms;

namespace BalotoRandom.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Error => Resource.Error;
        public static string Accept => Resource.Accept;
        public static string InternetError => Resource.InternetError;
        public static string Message => Resource.Message;
        public static string MessageProb => Resource.MessageProb;
        public static object Draw => Resource.Draw;
        public static string Available => Resource.Available;
        public static string Warning => Resource.Warning;
    }
}