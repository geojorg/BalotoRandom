using Android.Content;
using Android.Gms.Ads;
using BalotoRand.CustomRenderers;
using BalotoRandom.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]

namespace BalotoRand.CustomRenderers
{
    public class AdMobRenderer : ViewRenderer
    {
        public AdMobRenderer(Context context) : base(context)
        {

        }
        private int GetSmartBannerDpHeight()
        {
            var dpHeight = Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;
            if (dpHeight <= 400) return 32;
            if (dpHeight <= 720) return 50;
            return 90;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var ad = new AdView(Context)
                {
                    AdSize = AdSize.SmartBanner,
                    AdUnitId = "ca-app-pub-5943072479494249/9541702501"
                };

                var requestbuilder = new AdRequest.Builder();

                ad.LoadAd(requestbuilder.Build());
                e.NewElement.HeightRequest = GetSmartBannerDpHeight();

                SetNativeControl(ad);
            }
        }
    }
}

