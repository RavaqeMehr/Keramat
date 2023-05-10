using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IUpdateFamilyMemberSpecialDiseaseService : IScopedDependency {
        Task<bool> Exe(UpdateFamilyMemberSpecialDiseaseDto dto);
    }

    public class UpdateFamilyMemberSpecialDiseaseService : IUpdateFamilyMemberSpecialDiseaseService {
        private readonly IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyMemberSpecialDiseaseService(
            IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberSpecialDiseaseRepo = familyMemberSpecialDiseaseRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(UpdateFamilyMemberSpecialDiseaseDto dto) {
            var item = await familyMemberSpecialDiseaseRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Description = dto.Description;

            await familyMemberSpecialDiseaseRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDisease> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDisease,
                Root2Id = item.FamilyId,
                Root1Id = item.FamilyMemberId,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
