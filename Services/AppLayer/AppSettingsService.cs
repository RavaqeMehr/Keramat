using Common;
using Entities.AppSettings;

namespace Services.AppLayer {
    public interface IAppSettingsService : ISingletonDependency {
        void Set(List<AppSetting> settings);
        string? Get(string key);
    }

    public class AppSettingsService : IAppSettingsService {
        private List<AppSetting> settings { get; set; } = new();

        public string? Get(string key) => settings.FirstOrDefault(x => x.Key == key)?.Val;

        public void Set(List<AppSetting> settings) {
            this.settings = settings;
        }
    }
}
