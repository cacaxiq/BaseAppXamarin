using BaseApp.Core.Helpers;
using BaseApp.Core.Views;
using BaseApp.Models.Authorization;
using BaseApp.Models.Interfaces.Authorization;
using BaseApp.Service.Interface;
using BaseApp.Service.Services;
using Microsoft.Practices.Unity;
using Plugin.Settings.Abstractions;
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
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();


            InitServices(false);
        }

        protected void InitServices(bool mock = false)
        {
            Container.RegisterType<ISettings>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IToken, TokenConfiguration>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IValueService, ValueService>(new ContainerControlledLifetimeManager());
        }
    }
}
