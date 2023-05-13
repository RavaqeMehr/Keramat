using Common;
using Data;
using Entities.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace Services.AppLayer {
    public interface ISeedSettingService<T> : IScopedDependency {
        Task Set(int val);
        Task<int> Get();
    }

    public class SeedSettingService<T> : ISeedSettingService<T> {
        private readonly string key;
        private readonly IRepository<SeedsSetting> seedsSettingRepo;

        public SeedSettingService(
            IRepository<SeedsSetting> seedsSettingRepo
            ) {
            this.key = typeof(T).FullName ?? typeof(T).Name;
            this.seedsSettingRepo = seedsSettingRepo;
        }

        public async Task<int> Get() {
            var item = await seedsSettingRepo.TableNoTracking.FirstOrDefaultAsync(x => x.Key == key);

            return item?.Val ?? 0;
        }

        public async Task Set(int val) {
            var item = await seedsSettingRepo.TableNoTracking.FirstOrDefaultAsync(x => x.Key == key);
            if (item is null) {
                item = new SeedsSetting { Key = key, Val = val };
                await seedsSettingRepo.AddAsync(item);
            }
            else {
                item.Val = val;
                await seedsSettingRepo.UpdateAsync(item);
            }
        }
    }
}
