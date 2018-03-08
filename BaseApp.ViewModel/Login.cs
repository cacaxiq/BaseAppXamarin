using System;
using BaseApp.Core.ViewModels.Base;
using BaseApp.Models.Business.User;
using Prism.Commands;
using BaseApp.Service.Interface;
using BaseApp.Models.Authorization;
using BaseApp.Infrastructure.Services.UserService;
using Prism.Services;
using Prism.Navigation;
using BaseApp.Infrastructure.Constants;

namespace BaseApp.Core.ViewModels
{
    public class Login : ViewModelBase
    {
        public DelegateCommand GerarTokenCommand { get; }

        private IAccessControlService AccessControlService;
        private IPageDialogService DialogService;
        private IValuesService ValuesService;

        private LoginDTO userLogin;

        public LoginDTO UserLogin
        {
            get { return userLogin; }
            set { SetProperty(ref userLogin, value); }
        }

        public Login(
              IAccessControlService accessControlService
            , IPageDialogService dialogService
            , INavigationService navigationService) : base(navigationService)
        {
            UserLogin = new LoginDTO();

            GerarTokenCommand = new DelegateCommand(GenerateToken);

            AccessControlService = accessControlService;
            DialogService = dialogService;
        }

        private bool CanExecuteGenerateToken()
        {
            return !(string.IsNullOrEmpty(UserLogin.AccessKey) || string.IsNullOrEmpty(UserLogin.UserID));
        }

        private async void GenerateToken()
        {
            var retorno = await AccessControlService.GetUserToken(
                    new User
                    {
                        AccessKey = UserLogin.AccessKey,
                        UserID = UserLogin.UserID
                    }
                );

            if (retorno.IsSuccess)
            {
                await DialogService.DisplayAlertAsync("Sucesso", "Acesso Autorizado", "Ok");
                Settings.Token = retorno.Content.AccessToken;
                await NavigationService.NavigateAsync(BaseAppPageLinks.InicialPage);
            }
            else
            {
                await DialogService.DisplayAlertAsync("Negado", retorno.Message, "Ok");
            }
        }
    }
}
