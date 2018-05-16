using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CloudBaseLine.Localization
{
    public static class CloudBaseLineLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CloudBaseLineConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CloudBaseLineLocalizationConfigurer).GetAssembly(),
                        "CloudBaseLine.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
