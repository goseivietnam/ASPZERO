using System.Threading.Tasks;
using Abp.Application.Services;
using MyFisrtProjectASPNETZERO.Authorization.Accounts.Dto;

namespace MyFisrtProjectASPNETZERO.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
