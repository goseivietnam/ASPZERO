using System.Threading.Tasks;
using MyFisrtProjectASPNETZERO.Configuration.Dto;

namespace MyFisrtProjectASPNETZERO.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
