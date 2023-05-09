using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyMemberRelationService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyMemberRelationService : IRemoveFamilyMemberRelationService {
        private readonly IRepository<FamilyMemberRelation> familyMemberRelationRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyMemberRelationService(
            IRepository<FamilyMemberRelation> familyMemberRelationRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberRelationRepo = familyMemberRelationRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyMemberRelationRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyMemberRelationRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberRelation> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberRelation,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
