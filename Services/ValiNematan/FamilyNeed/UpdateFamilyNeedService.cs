using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IUpdateFamilyNeedService : IScopedDependency {
        Task<bool> Exe(UpdateFamilyNeedDto dto);
    }

    public class UpdateFamilyNeedService : IUpdateFamilyNeedService {
        private readonly IRepository<FamilyNeed> familyNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyNeedService(
            IRepository<FamilyNeed> familyNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedRepo = familyNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(UpdateFamilyNeedDto dto) {
            var item = await familyNeedRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Description = dto.Description;

            await familyNeedRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeed> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeed,
                Root1Id = item.FamilyId,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
