using BalotoRand.CustomRenderers;
using BalotoRandom.Controls;
using CoreGraphics;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobViewRenderer))]
namespace BalotoRand.CustomRenders
{
    public class AdMobViewRenderer : ViewRenderer
    {
        const string AdmobID = "ca-app-pub-5943072479494249/9541702501";
        BannerView adView;
        bool viewOnScreen;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {
                adView = new BannerView(size: AdSizeCons.Banner, origin: new CGPoint(-10, 0))
                {
                    RootViewController = UIApplication.SharedApplication.Windows[0].RootViewController
                };
                adView.AdUnitId = AdmobID;
                adView.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen) this.AddSubview(adView);
                    viewOnScreen = true;
                };
 
                adView.LoadRequest(Request.GetDefaultRequest());
                base.SetNativeControl(adView);
            }
        }

        private int GetSmartBannerDpHeight()
        {
            var dpHeight = (double)UIScreen.MainScreen.Bounds.Height;

            if (dpHeight <= 400) return 32;
            if (dpHeight <= 720) return 50;
            return 90;
        }
    }
}