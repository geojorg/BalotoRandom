using BalotoRandom.iOS.DependencyServices;
using BalotoRandom.Services;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdMobInterstitial))]
namespace BalotoRandom.iOS.DependencyServices
{
    public class AdMobInterstitial : IAdInterstitial
    {
        Interstitial interstitialAd;

        public AdMobInterstitial()
        {
            LoadAd();
            interstitialAd.ScreenDismissed += (s, e) => LoadAd();
        }

        void LoadAd()
        {
            interstitialAd = new Interstitial("ca-app-pub-5943072479494249/2953024649");
            var requestbuilder = Request.GetDefaultRequest();
            //request.TestDevices = new string[] { "Your Test Device ID", "GADSimulator" }; To Test in the Emulator.
            interstitialAd.LoadRequest(requestbuilder);
        }

        public void ShowAd()
        {
            if (interstitialAd.IsReady)
            {
                var viewController = GetVisibleViewController();
                interstitialAd.Present(viewController);
            }
        }
        UIViewController GetVisibleViewController()
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            if (rootController.PresentedViewController == null)
                return rootController;

            if (rootController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootController.PresentedViewController).VisibleViewController;
            }

            if (rootController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
            }

            return rootController.PresentedViewController;
        }
    }
}