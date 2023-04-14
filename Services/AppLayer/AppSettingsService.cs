using Common;
using Data;
using Entities.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace Services.AppLayer {
    public interface IAppSettingsService : ISingletonDependency {
        Task<string> Get(string key);
        Task Set(string key, string value);
    }

    public class AppSettingsService : IAppSettingsService {
        private readonly IRepository<AppSetting> settingsRepo;
        private List<AppSetting>? _settings { get; set; }

        public AppSettingsService(
            IRepository<AppSetting> settingsRepo
            ) {
            this.settingsRepo = settingsRepo;
        }

        public async Task<string> Get(string key) {
            if (_settings is null) {
                _settings = await settingsRepo.TableNoTracking.ToListAsync();

            }
            return _settings.First(x => x.Key == key).Val;
        }

        public async Task Set(string key, string value) {
            if (_settings.Count(x => x.Key == key) == 0) {
                var thisSetting = new AppSetting { Key = key, Val = value };
                await settingsRepo.AddAsync(thisSetting);
                _settings.Add(thisSetting);
            }
            else {
                var thisSetting = _settings.First(x => x.Key == key);
                _settings.Remove(thisSetting);
                thisSetting.Val = value;

                await settingsRepo.UpdateAsync(thisSetting);
                _settings.Add(thisSetting);
            }
        }
    }
}
