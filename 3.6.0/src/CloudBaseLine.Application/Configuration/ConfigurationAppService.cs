using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CloudBaseLine.Configuration.Dto;

namespace CloudBaseLine.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CloudBaseLineAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
