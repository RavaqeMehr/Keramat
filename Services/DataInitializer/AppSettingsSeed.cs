﻿
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

        public int Order => 10;

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

                    goto default;
                default:
                    break;
            }

            if (lastInstalledVer > 0) {
                var savedVer = settingsRepo.TableNoTracking.First(x => x.Key == AppSettingsKeys.Last_Installed_Version);
                savedVer.Val = thisVerNum.ToString();
                settingsUpdate.Add(savedVer);
            }

            if (settingsAdd.Count > 0) {
                await settingsRepo.AddRangeAsync(settingsAdd);
            }

            if (settingsUpdate.Count > 0) {
                await settingsRepo.UpdateRangeAsync(settingsUpdate);
            }
        }
    }
}
