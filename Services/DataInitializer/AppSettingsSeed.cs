
using Data;
using Entities.AppSettings;
using Services.AppLayer;

namespace Services.DataInitializer {
    public class AppSettingsSeed : IDataInitializer {
        private readonly IAppVersionService appVersionService;
        private readonly IRepository<AppSetting> settingsRepo;

        public AppSettingsSeed(
            IAppVersionService appVersionService,
            IRepository<AppSetting> settingsRepo
            ) {
            this.appVersionService = appVersionService;
            this.settingsRepo = settingsRepo;
        }

        public int Order => 0;

        public async void InitializeData() {
            var thisVerNum = appVersionService.VersionNumber();
            var lastInstalledVerItem = settingsRepo.TableNoTracking.
                FirstOrDefault(x => x.Key == AppSettingsKeys.Last_Installed_Version);
            var lastInstalledVer = lastInstalledVerItem is null ? 0 : int.Parse(lastInstalledVerItem.Val);

            var settingsAdd = new List<AppSetting>();
            var settingsUpdate = new List<AppSetting>();
            switch (lastInstalledVer) {
                case 0:
                    settingsAdd.Add(new AppSetting {
                        Key = AppSettingsKeys.Last_Installed_Version,
                        Val = thisVerNum.ToString()
                    });

                    settingsAdd.Add(new AppSetting {
                        Key = AppSettingsKeys.Ui_Fonts_Defaults_Family,
                        Val = "Vazirmatn"
                    });

                    settingsAdd.Add(new AppSetting {
                        Key = AppSettingsKeys.Ui_Fonts_Defaults_Size,
                        Val = "14"
                    });

                    goto case 1;
                case 1:
                    settingsAdd.Add(new AppSetting {
                        Key = AppSettingsKeys.Charity_Name,
                        Val = "خیریه کرامت"
                    });
                    settingsAdd.Add(new AppSetting {
                        Key = AppSettingsKeys.Charity_Slogan,
                        Val = "تعجیل در فرج آقاجان صاحب‌الزمان صلوات"
                    });

                    settingsUpdate.Add(new AppSetting {
                        Key = AppSettingsKeys.Last_Installed_Version,
                        Val = thisVerNum.ToString()
                    });

                    goto default;
                default:
                    break;
            }

            if (settingsAdd.Count > 0) {
                settingsRepo.AddRange(settingsAdd);
            }

            if (settingsUpdate.Count > 0) {
                settingsRepo.UpdateRange(settingsUpdate);
            }
        }
    }
}
