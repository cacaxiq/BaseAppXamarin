using Prism.Mvvm;
using Prism.Navigation;

namespace BaseApp.Core.ViewModels.Base
{
    public class ViewModelBase : BindableBase, INavigationAware
    {

        public INavigationService NavigationService;

        public ViewModelBase()
        {

        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
