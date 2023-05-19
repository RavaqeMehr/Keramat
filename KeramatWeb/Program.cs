using Autofac;
using Autofac.Extensions.DependencyInjection;
using Frameworks.Configurations;
using Frameworks.Middlewares;
using Frameworks.Swagger;
using Services.AppLayer;
using System.Diagnostics;

IServiceProvider serviceProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddServices());

const int port = 1404;
builder.WebHost
    .UseKestrel(k => {
        k.ListenAnyIP(port);
    })
    .UseIISIntegration()
    .UseUrls($"http://0.0.0.0:{port}");


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCustomApiVersioning();
builder.Services.AddSwagger();

var app = builder.Build();

serviceProvider = app.Services;

try {
    app.UseSwaggerAndUI();

    app.IntializeDatabase();
    app.UseCustomExceptionHandler();
    app.UseStaticFiles();
    app.UseRouting();

    app.MapControllerRoute(
        name: "default",
        pattern: "api/{controller=Home}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");

    using (var tmpScope = serviceProvider.CreateScope()) {
        tmpScope.ServiceProvider.GetRequiredService<ILoadAppSettingsService>().Exe().ConfigureAwait(false);
    }

    Process.Start(new ProcessStartInfo { UseShellExecute = true, FileName = $"http://localhost:{port}" });
    app.Run();
}
catch (Exception e) {
    Console.Write("Error! \n{0}", e.Message);
}
finally {
    app.Lifetime.StopApplication();
}

Environment.Exit(110);

Console.Read();
