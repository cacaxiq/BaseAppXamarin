using BaseApp.Infrastructure.Constants;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace BaseApp.Core.ViewModels.Base
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public INavigationService NavigationService;

        public ViewModelBase(INavigationService navigationService = null)
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

        #region AdMob
        private string _adUnitId;
        public string AdUnitId
        {
            get { return _adUnitId; }
            set { SetProperty(ref _adUnitId, value); }
        }

        public void SetIdAdMob()
        {
            if (Device.RuntimePlatform == Device.iOS)
                AdUnitId = BaseAppConstants.AdmobKeyiOS;
            else if (Device.RuntimePlatform == Device.Android)
                AdUnitId = BaseAppConstants.AdmobKeyAndroid;
        }
        #endregion
    }
}
