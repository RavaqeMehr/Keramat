using Data;
using Entities.Services;
using Services.AppLayer;

namespace Services.DataInitializer {
    public class ServicesSeed : IDataInitializer {
        private readonly ISeedSettingService<ServicesSeed> seedSettingService;
        private readonly IRepository<ServiceSubject> serviceSubjectRepo;

        public ServicesSeed(
            ISeedSettingService<ServicesSeed> seedSettingService,
            IRepository<ServiceSubject> serviceSubjectRepo
            ) {
            this.seedSettingService = seedSettingService;
            this.serviceSubjectRepo = serviceSubjectRepo;
        }

        public int Order => 20;

        public async void InitializeData() {
            var ver = await seedSettingService.Get();

            var serviceSubjectAdd = new List<ServiceSubject>();

            if (ver < 1) {
                serviceSubjectAdd.Add(new ServiceSubject { Title = "کمک نقدی" });
                serviceSubjectAdd.Add(new ServiceSubject { Title = "بسته ارزاق" });
                serviceSubjectAdd.Add(new ServiceSubject { Title = "ویزیت رایگان" });

                ver = 1;
            }

            if (serviceSubjectAdd.Count > 0) {
                await serviceSubjectRepo.AddRangeAsync(serviceSubjectAdd);
            }

            await seedSettingService.Set(ver);
        }
    }
}
