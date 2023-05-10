using Common;
using Data;
using Entities.AppSettings;
using Services.AppLayer.Models;

namespace Services.AppLayer {
    public interface IUpdateSettingsService : IScopedDependency {
        Task<bool> Exe(UpdateSettingsDto dto);
    }

    public class UpdateSettingsService : IUpdateSettingsService {
        private readonly IAppSettingsService appSettingsService;
        private readonly IRepository<AppSetting> settingsRepo;

        public UpdateSettingsService(
            IAppSettingsService appSettingsService,
            IRepository<AppSetting> settingsRepo
            ) {
            this.appSettingsService = appSettingsService;
            this.settingsRepo = settingsRepo;
        }

        public async Task<bool> Exe(UpdateSettingsDto dto) {
            var _name = settingsRepo.TableNoTracking.First(x => x.Key == AppSettingsKeys.Charity_Name);
            _name.Val = dto.CharityName;
            var _slogan = settingsRepo.TableNoTracking.First(x => x.Key == AppSettingsKeys.Charity_Slogan);
            _slogan.Val = dto.CharitySlogan;
            await settingsRepo.UpdateRangeAsync(new[] { _name, _slogan });

            await appSettingsService.Load();
            return true;
        }
    }
}
