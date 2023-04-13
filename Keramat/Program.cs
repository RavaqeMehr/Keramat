using Autofac;
using Autofac.Extensions.DependencyInjection;
using Frameworks.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Keramat {
    internal static class Program {
        [STAThread]
        static void Main() {
            ApplicationConfiguration.Initialize();

            if (!Directory.Exists("data")) {
                Directory.CreateDirectory("data");
            }

            var host = Host.CreateDefaultBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder => {
                    builder.AddServices();
                    builder.AddForms<Form>(typeof(Program));
                })
                .ConfigureServices((context, services) => {
                    services
                    .AddDbContext(context.Configuration);
                })
                .Build();

            ServiceProvider = host.Services;

            host.IntializeDatabase();


            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IServiceProvider ServiceProvider { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }

}