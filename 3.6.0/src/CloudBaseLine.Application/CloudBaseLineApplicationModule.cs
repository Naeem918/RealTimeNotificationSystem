using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CloudBaseLine.Authorization;

namespace CloudBaseLine
{
    [DependsOn(
        typeof(CloudBaseLineCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CloudBaseLineApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CloudBaseLineAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CloudBaseLineApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
