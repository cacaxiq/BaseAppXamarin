using BaseApp.Models.Core;
using BaseApp.Service.Core;
using System.Threading.Tasks;

namespace BaseApp.Service.Interface
{
    public interface IServiceBase
    {
        string ServiceName { get; }
        string Token { get; }
        int RetriesNumber { get; }
    }
}
