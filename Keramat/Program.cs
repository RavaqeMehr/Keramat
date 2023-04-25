using Autofac;
using Autofac.Extensions.DependencyInjection;
using Frameworks.Configurations;
using Keramat.Forms.Dashboard;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.AppUsingLogs;
using System.Diagnostics;

namespace Keramat {
    internal static class Program {
        static Process checker;
        static Process main;
        static int mainProcessID;

        static IAppSessionService appSessionService;

        [STAThread]
        static async Task Main(string[] args) {
            if (args.Length == 0) //Main App Process.
            {
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
                        services.AddDbContext();
                    })
                    .Build();

                ServiceProvider = host.Services;

                host.IntializeDatabase();

                //var fontService = ServiceProvider.GetRequiredService<IFontsService>();
                //await fontService.Load();
                //Application.SetDefaultFont(fontService.FontByRatio(1));

                //Saves current process info to pass on command line.
                main = Process.GetCurrentProcess();
                mainProcessID = main.Id;

                //Initializes the helper process
                checker = new Process();
                checker.StartInfo.FileName = main.MainModule.FileName;
                checker.StartInfo.Arguments = mainProcessID.ToString();

                checker.EnableRaisingEvents = true;
                checker.Exited += new EventHandler(OnApplicationCheckerExit);

                //Launch the helper process.
                checker.Start();

                Application.ApplicationExit += OnApplicationExit;
                appSessionService = ServiceProvider.GetRequiredService<IAppSessionService>();

                OnApplicationStart();
                Application.Run(ServiceProvider.GetRequiredService<MainForm>());
            }
            else //On the helper Process
            {
                main = Process.GetProcessById(int.Parse(args[0]));

                main.EnableRaisingEvents = true;
                main.Exited += OnApplicationExit;

                while (!main.HasExited) {
                    Thread.Sleep(1000); //Wait 1 second. 
                }

                //Provide some time to process the main_Exited event. 
                Thread.Sleep(5000);
            }


        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static IServiceProvider ServiceProvider { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private static async void OnApplicationStart() {
            await appSessionService.Start();
        }
        private static async void OnApplicationExit(object? sender, EventArgs e) {
            await appSessionService.Stop();
        }
        private static async void OnApplicationCheckerExit(object? sender, EventArgs e) {
            await appSessionService.Stop();
            main.Kill();
        }
    }

}