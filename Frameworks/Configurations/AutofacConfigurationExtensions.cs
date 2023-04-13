using Autofac;
using Common;
using Data;
using Entities.Common;
using Services.DataInitializer;

namespace Frameworks.Configurations {
    public static class AutofacConfigurationExtensions {
        public static void AddServices(this ContainerBuilder containerBuilder) {
            //RegisterType > As > Liftetime
            containerBuilder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

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

        public static void AddForms<TForm>(this ContainerBuilder containerBuilder, Type programType) {
            containerBuilder.RegisterAssemblyTypes(programType.Assembly)
                    .AssignableTo<TForm>()
                    .InstancePerDependency();
        }
    }
}
