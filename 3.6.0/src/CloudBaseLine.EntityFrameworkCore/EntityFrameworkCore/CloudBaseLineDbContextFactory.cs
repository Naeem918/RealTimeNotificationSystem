using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CloudBaseLine.Configuration;
using CloudBaseLine.Web;

namespace CloudBaseLine.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CloudBaseLineDbContextFactory : IDesignTimeDbContextFactory<CloudBaseLineDbContext>
    {
        public CloudBaseLineDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CloudBaseLineDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CloudBaseLineDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CloudBaseLineConsts.ConnectionStringName));

            return new CloudBaseLineDbContext(builder.Options);
        }
    }
}
