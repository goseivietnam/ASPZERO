using Abp.AutoMapper;
using MyFisrtProjectASPNETZERO.Authentication.External;

namespace MyFisrtProjectASPNETZERO.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
