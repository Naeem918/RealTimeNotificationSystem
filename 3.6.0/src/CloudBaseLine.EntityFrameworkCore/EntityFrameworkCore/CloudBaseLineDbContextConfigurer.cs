using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CloudBaseLine.EntityFrameworkCore
{
    public static class CloudBaseLineDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CloudBaseLineDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CloudBaseLineDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
