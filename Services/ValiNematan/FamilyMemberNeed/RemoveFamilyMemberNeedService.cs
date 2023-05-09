using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyMemberNeedService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyMemberNeedService : IRemoveFamilyMemberNeedService {
        private readonly IRepository<FamilyMemberNeed> familyMemberNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyMemberNeedService(
            IRepository<FamilyMemberNeed> familyMemberNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberNeedRepo = familyMemberNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyMemberNeedRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyMemberNeedRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeed> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeed,
                Root2Id = item.FamilyId,
                Root1Id = item.FamilyMemberId,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
