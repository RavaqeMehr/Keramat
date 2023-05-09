using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IUpdateFamilyMemberNeedService : IScopedDependency {
        Task<bool> Exe(UpdateFamilyMemberNeedDto dto);
    }

    public class UpdateFamilyMemberNeedService : IUpdateFamilyMemberNeedService {
        private readonly IRepository<FamilyMemberNeed> familyMemberNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyMemberNeedService(
            IRepository<FamilyMemberNeed> familyMemberNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberNeedRepo = familyMemberNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(UpdateFamilyMemberNeedDto dto) {
            var item = await familyMemberNeedRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Description = dto.Description;

            await familyMemberNeedRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeed> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeed,
                Root2Id = item.FamilyId,
                Root1Id = item.FamilyMemberId,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
