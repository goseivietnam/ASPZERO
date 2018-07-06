using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyFisrtProjectASPNETZERO.MultiTenancy.Dto;

namespace MyFisrtProjectASPNETZERO.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
