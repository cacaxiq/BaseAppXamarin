using BaseApp.Core.Views;
using BaseApp.Infrastructure.Constants;
using BaseApp.Infrastructure.Services.UserService;
using BaseApp.Service.Interface;
using BaseApp.Service.Services;
using Prism;
using Prism.Ioc;
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();

            InitServices(containerRegistry);
        }

        protected void InitServices(IContainerRegistry containerRegistry, bool mock = false)
        {
            containerRegistry.Register<ISettingsUser, SettingsUser>();
            containerRegistry.Register<IAccessControlService, AccessControlService>();
            containerRegistry.Register<IValuesService, ValuesService>();
        }
    }
}
