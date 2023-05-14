
using Data;
using Entities.AppSettings;
using Services.AppLayer;

namespace Services.DataInitializer {
    public class AppSettingsSeed : IDataInitializer {
        private readonly ISeedSettingService<AppSettingsSeed> seedSettingService;
        private readonly IRepository<AppSetting> settingsRepo;

        public AppSettingsSeed(
            ISeedSettingService<AppSettingsSeed> seedSettingService,
            IRepository<AppSetting> settingsRepo
            ) {
            this.seedSettingService = seedSettingService;
            this.settingsRepo = settingsRepo;
        }

        public int Order => 10;

        public async void InitializeData() {
            var ver = await seedSettingService.Get();

            var settingsAdd = new List<AppSetting>();
            var settingsUpdate = new List<AppSetting>();

            if (ver < 1) {
                settingsAdd.Add(new AppSetting {
                    Key = AppSettingsKeys.Charity_Name,
                    Val = "خیریه کرامت"
                });
                settingsAdd.Add(new AppSetting {
                    Key = AppSettingsKeys.Charity_Slogan,
                    Val = "تعجیل در فرج آقاجان صاحب‌الزمان صلوات"
                });

                ver = 1;
            }


            if (settingsAdd.Count > 0) {
                await settingsRepo.AddRangeAsync(settingsAdd);
            }

            if (settingsUpdate.Count > 0) {
                await settingsRepo.UpdateRangeAsync(settingsUpdate);
            }

            await seedSettingService.Set(ver);
        }
    }
}
