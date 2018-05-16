using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CloudBaseLine.Configuration;
using CloudBaseLine.EntityFrameworkCore;
using CloudBaseLine.Migrator.DependencyInjection;

namespace CloudBaseLine.Migrator
{
    [DependsOn(typeof(CloudBaseLineEntityFrameworkModule))]
    public class CloudBaseLineMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CloudBaseLineMigratorModule(CloudBaseLineEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(CloudBaseLineMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                CloudBaseLineConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CloudBaseLineMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
