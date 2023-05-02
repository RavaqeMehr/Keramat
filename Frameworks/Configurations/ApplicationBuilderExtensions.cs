using Common.Utilities;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.DataInitializer;

namespace Frameworks.Configurations {
    public static class ApplicationBuilderExtensions {
        public static void AddDbContext(this IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(options => {
                options
                    .UseSqlite("Data Source=data/Keramat.db;Cache=Shared");
            });
        }

        public static IHost IntializeDatabase(this IHost app) {
            Assert.NotNull(app, nameof(app));

            //Use C# 8 using variables
            using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>(); //Service locator

            if (dbContext is null) {
                throw new Exception("ApplicationDbContext is NULL");
            }

            //Dos not use Migrations, just Create Database with latest changes
            //dbContext.Database.EnsureCreated();
            //Applies any pending migrations for the context to the database like (Update-Database)
            dbContext.Database.Migrate();

            var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>();
            var orderedList = dataInitializers.OrderBy(x => x.Order);
            foreach (var dataInitializer in orderedList)
                dataInitializer.InitializeData();

            return app;
        }

        public static void AddCustomApiVersioning(this IServiceCollection services) {
            services.AddApiVersioning(options => {
                //url segment => {version}
                options.AssumeDefaultVersionWhenUnspecified = true; //default => false;
                options.DefaultApiVersion = new ApiVersion(1, 0); //v1.0 == v1
                options.ReportApiVersions = true;
            });
        }
    }
}
