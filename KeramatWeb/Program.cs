using Autofac;
using Autofac.Extensions.DependencyInjection;
using Frameworks.Configurations;
using Frameworks.Middlewares;
using Frameworks.Swagger;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Services.AppLayer;
using Services.AppUsingLogs;

IServiceProvider serviceProvider;
IAppSessionService appSessionService;

var filesPath = @"data\files";
if (!Directory.Exists(filesPath)) {
    Directory.CreateDirectory(filesPath);
}

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddServices());

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCustomApiVersioning();
builder.Services.AddSwagger();

var app = builder.Build();

serviceProvider = app.Services;
appSessionService = serviceProvider.GetRequiredService<IAppSessionService>();

try {

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
        app.UseSwaggerAndUI();
    }
    else {
        // just for local use only
        app.UseSwaggerAndUI();

        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        app.UseHttpsRedirection();
    }

    app.IntializeDatabase();
    app.UseCustomExceptionHandler();

    FileExtensionContentTypeProvider contentTypes = new FileExtensionContentTypeProvider();
    contentTypes.Mappings[".apk"] = "application/vnd.android.package-archive";
    app.UseStaticFiles(new StaticFileOptions() {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), filesPath)),
        RequestPath = new PathString("/Files"),
        ContentTypeProvider = contentTypes
    });

    app.UseRouting();


    app.MapControllerRoute(
        name: "default",
        pattern: "api/{controller=Home}/{action=Index}/{id?}");

    app.MapFallbackToFile("index.html");


    appSessionService.Start().ConfigureAwait(false);
    serviceProvider.GetRequiredService<IAppSettingsService>().Load().ConfigureAwait(false);
    app.Run();
}
catch (Exception e) {

}
finally {
    appSessionService.Stop().ConfigureAwait(false);
}


