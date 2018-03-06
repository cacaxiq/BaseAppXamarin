using Android.App;
using Android.Content.PM;
using Android.OS;
using BaseApp.Core;
using BaseApp.Infrastructure.Constants;
using Prism;
using Prism.Ioc;

namespace BaseApp.Droid
{
    [Activity(Label = "BaseApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            InitializePlugins();
            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App(new AndroidInitializer()));
        }

        private void InitializePlugins()
        {
            global::Android.Gms.Ads.MobileAds.Initialize(ApplicationContext, BaseAppConstants.AdmobKeyAndroid);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry) { }
    }
}

