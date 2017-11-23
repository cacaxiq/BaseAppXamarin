using BaseApp.Core.Views;
using BaseApp.Infrastructure.Constants;
using BaseApp.Infrastructure.Services.UserService;
using BaseApp.Service.Interface;
using BaseApp.Service.Services;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms.Xaml;

namespace BaseApp.Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(BaseAppPageLinks.LoginPage);
        }

        public App() : this(null) { }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<LoginPage>();

            InitServices(false);
        }

        protected void InitServices(bool mock = false)
        {
            Container.RegisterType<ISettingsUser, SettingsUser>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAccessControlService, AccessControlService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IValuesService, ValuesService>(new ContainerControlledLifetimeManager());
        }
    }
}
