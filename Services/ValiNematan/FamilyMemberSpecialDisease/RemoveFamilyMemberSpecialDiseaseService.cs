using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyMemberSpecialDiseaseService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyMemberSpecialDiseaseService : IRemoveFamilyMemberSpecialDiseaseService {
        private readonly IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyMemberSpecialDiseaseService(
            IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberSpecialDiseaseRepo = familyMemberSpecialDiseaseRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyMemberSpecialDiseaseRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyMemberSpecialDiseaseRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDisease> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDisease,
                Root2Id = item.FamilyId,
                Root1Id = item.FamilyMemberId,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
