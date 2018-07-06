using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyFisrtProjectASPNETZERO.Localization
{
    public static class MyFisrtProjectASPNETZEROLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MyFisrtProjectASPNETZEROConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyFisrtProjectASPNETZEROLocalizationConfigurer).GetAssembly(),
                        "MyFisrtProjectASPNETZERO.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
