using BaseApp.Models.Authorization;
using BaseApp.Service.Core;
using System.Threading.Tasks;

namespace BaseApp.Service.Interface
{
    public interface IAccessControlService
    {
        Task<RespostaPadrão<Token>> GetUserToken(User user);
    }
}
