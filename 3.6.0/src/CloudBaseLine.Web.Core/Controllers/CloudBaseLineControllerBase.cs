using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CloudBaseLine.Controllers
{
    public abstract class CloudBaseLineControllerBase: AbpController
    {
        protected CloudBaseLineControllerBase()
        {
            LocalizationSourceName = CloudBaseLineConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
