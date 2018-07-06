using System.Collections.Generic;

namespace MyFisrtProjectASPNETZERO.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
