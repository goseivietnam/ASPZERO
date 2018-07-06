using System.Threading.Tasks;
using Abp.Application.Services;
using MyFisrtProjectASPNETZERO.Sessions.Dto;

namespace MyFisrtProjectASPNETZERO.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
