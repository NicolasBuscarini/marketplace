using MarketPlace.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Impl.Service;

public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceMySql = serviceScope.ServiceProvider.GetService<MySqlContext>();
                
                var migrator = serviceMySql.GetInfrastructure().GetService<IMigrator>();

                migrator.Migrate();
            }
        }
    }