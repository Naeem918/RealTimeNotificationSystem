using System.Threading.Tasks;
using CloudBaseLine.Configuration.Dto;

namespace CloudBaseLine.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
