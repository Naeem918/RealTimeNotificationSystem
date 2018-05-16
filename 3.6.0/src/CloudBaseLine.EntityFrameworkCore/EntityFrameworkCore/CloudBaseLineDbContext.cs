using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CloudBaseLine.Authorization.Roles;
using CloudBaseLine.Authorization.Users;
using CloudBaseLine.MultiTenancy;

namespace CloudBaseLine.EntityFrameworkCore
{
    public class CloudBaseLineDbContext : AbpZeroDbContext<Tenant, Role, User, CloudBaseLineDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CloudBaseLineDbContext(DbContextOptions<CloudBaseLineDbContext> options)
            : base(options)
        {
        }
    }
}
