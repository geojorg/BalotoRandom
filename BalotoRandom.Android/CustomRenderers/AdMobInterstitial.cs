using Android.Gms.Ads;
using Android.Util;
using BalotoRand.CustomRenderers;
using BalotoRandom.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdMobInterstitial))]
namespace BalotoRand.CustomRenderers
{
    public class AdMobInterstitial : IAdInterstitial
    {
        InterstitialAd interstitialAd;

        public AdMobInterstitial()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);
            interstitialAd.AdUnitId = "ca-app-pub-5943072479494249/2953024649";
            LoadAd();
        }

        void LoadAd()
        {
            var requestbuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestbuilder.Build());
        }

        public void ShowAd()
        {
            if (interstitialAd.IsLoaded)
            {
                interstitialAd.Show();
            }
            else
            {
                Log.Debug("TAG", "The interstitial wasn't loaded yet.");
            }
            LoadAd();
        }
    }
}