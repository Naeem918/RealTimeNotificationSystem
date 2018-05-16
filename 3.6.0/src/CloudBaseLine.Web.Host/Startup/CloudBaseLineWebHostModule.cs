using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CloudBaseLine.Configuration;

namespace CloudBaseLine.Web.Host.Startup
{
    [DependsOn(
       typeof(CloudBaseLineWebCoreModule))]
    public class CloudBaseLineWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CloudBaseLineWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CloudBaseLineWebHostModule).GetAssembly());
        }
    }
}
