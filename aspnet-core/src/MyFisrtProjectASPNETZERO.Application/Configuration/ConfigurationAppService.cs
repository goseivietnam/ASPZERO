using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyFisrtProjectASPNETZERO.Configuration.Dto;

namespace MyFisrtProjectASPNETZERO.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyFisrtProjectASPNETZEROAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
