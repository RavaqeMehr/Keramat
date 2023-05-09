using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IUpdateFamilyMemberRelationService : IScopedDependency {
        Task<bool> Exe(FamilyMemberRelation dto);
    }

    public class UpdateFamilyMemberRelationService : IUpdateFamilyMemberRelationService {
        private readonly IRepository<FamilyMemberRelation> familyRelationRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyMemberRelationService(
            IRepository<FamilyMemberRelation> familyRelationRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyRelationRepo = familyRelationRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(FamilyMemberRelation dto) {
            var item = await familyRelationRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Title = dto.Title;
            item.Description = dto.Description;

            await familyRelationRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberRelation> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberRelation,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
