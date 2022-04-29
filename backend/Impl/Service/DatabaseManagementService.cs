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
            Console.WriteLine("11111111");
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Console.WriteLine("22222222");
                var serviceMySql = serviceScope.ServiceProvider.GetService<MySqlContext>();
                
                var migrator = serviceMySql.GetInfrastructure().GetService<IMigrator>();

                migrator.Migrate();
                
                Console.WriteLine("3333333333");
            }
        }
    }