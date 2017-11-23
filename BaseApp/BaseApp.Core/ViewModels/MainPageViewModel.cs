using BaseApp.Core.ViewModels.Base;
using BaseApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseApp.Core.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IValuesService ValuesService;

        public MainPageViewModel(IValuesService valuesService)
        {
            ValuesService = valuesService;
            Carrega();
        }

        private async void Carrega()
        {
            var retorno = await ValuesService.Teste(5);
            Teste = retorno.Content;
        }

        private string teste;

        public string Teste
        {
            get { return teste; }
            set { SetProperty(ref teste, value); }
        }

    }
}
