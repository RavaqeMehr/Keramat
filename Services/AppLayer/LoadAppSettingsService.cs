using Common;
using Data;
using Entities.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace Services.AppLayer {
    public interface ILoadAppSettingsService : IScopedDependency {
        Task Exe();
    }

    public class LoadAppSettingsService : ILoadAppSettingsService {
        private readonly IRepository<AppSetting> repo;
        private readonly IAppSettingsService appSettingsService;

        public LoadAppSettingsService(
            IRepository<AppSetting> repo,
            IAppSettingsService appSettingsService
            ) {
            this.repo = repo;
            this.appSettingsService = appSettingsService;
        }

        public async Task Exe() {
            var items = await repo.TableNoTracking.ToListAsync();
            appSettingsService.Set(items);
        }
    }
}
