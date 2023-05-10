using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IUpdateFamilyLevelService : IScopedDependency {
        Task<bool> Exe(UpdateFamilyLevelDto dto);
    }

    public class UpdateFamilyLevelService : IUpdateFamilyLevelService {
        private readonly IRepository<FamilyLevel> familyLevelRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyLevelService(
            IRepository<FamilyLevel> familyLevelRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyLevelRepo = familyLevelRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(UpdateFamilyLevelDto dto) {
            var item = await familyLevelRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Title = dto.Title;
            item.Level = dto.Level;
            item.Description = dto.Description;

            await familyLevelRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyLevel> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyLevel,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
