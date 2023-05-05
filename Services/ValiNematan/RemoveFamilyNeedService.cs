using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyNeedService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyNeedService : IRemoveFamilyNeedService {
        private readonly IRepository<FamilyNeed> familyNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyNeedService(
            IRepository<FamilyNeed> familyNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedRepo = familyNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyNeedRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyNeedRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeed> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeed,
                Root1Id = item.FamilyId,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
