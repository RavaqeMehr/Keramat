using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyLevelService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyLevelService : IRemoveFamilyLevelService {
        private readonly IRepository<FamilyLevel> familyLevelRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyLevelService(
            IRepository<FamilyLevel> familyLevelRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyLevelRepo = familyLevelRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyLevelRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyLevelRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyLevel> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyLevel,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
