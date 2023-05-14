using Autofac;
using Common;
using Data;
using Entities.Common;
using Services.AppLayer;
using Services.DataInitializer;

namespace Frameworks.Configurations {
    public static class AutofacConfigurationExtensions {
        public static void AddServices(this ContainerBuilder containerBuilder) {
            //RegisterType > As > Liftetime for GENERIC
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            containerBuilder.RegisterGeneric(typeof(SeedSettingService<>)).As(typeof(ISeedSettingService<>)).InstancePerLifetimeScope();

            var commonAssembly = typeof(IScopedDependency).Assembly;
            var entitiesAssembly = typeof(IEntity).Assembly;
            var dataAssembly = typeof(ApplicationDbContext).Assembly;
            var servicesAssembly = typeof(IDataInitializer).Assembly;

            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
                .AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            containerBuilder.RegisterAssemblyTypes(commonAssembly, entitiesAssembly, dataAssembly, servicesAssembly)
                .AssignableTo<ISingletonDependency>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }

    }
}
