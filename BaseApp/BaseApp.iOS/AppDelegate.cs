using BaseApp.Core;
using BaseApp.Infrastructure.Constants;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;

namespace BaseApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            InitializePlugins();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }

        private void InitializePlugins()
        {
            Google.MobileAds.MobileAds.Configure(BaseAppConstants.AdmobKeyiOS);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry) { }
    }
}
