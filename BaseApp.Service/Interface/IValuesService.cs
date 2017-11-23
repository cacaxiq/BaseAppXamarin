using BaseApp.Service.Core;
using System.Threading.Tasks;

namespace BaseApp.Service.Interface
{
    public interface IValuesService 
    {
        Task<RespostaPadrão<string>> Teste(int id);
    }
}
