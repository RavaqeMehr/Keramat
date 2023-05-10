using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IUpdateFamilyService : IScopedDependency {
        Task<bool> Exe(UpdateFamilyDto dto);
    }

    public class UpdateFamilyService : IUpdateFamilyService {
        private readonly IRepository<Family> familyRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyService(
            IRepository<Family> familyRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyRepo = familyRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(UpdateFamilyDto dto) {
            var item = await familyRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Title = dto.Title;
            item.Address = dto.Address;
            item.LevelId = dto.LevelId;
            item.Description = dto.Description;
            item.ContactPersonName = dto.ContactPersonName;
            item.ContactPersonPhone = dto.ContactPersonPhone;
            item.ContactPersonDescription = dto.ContactPersonDescription;
            item.ConnectorId = dto.ConnectorId;
            item.Finished = dto.Finished;

            await familyRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Family> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.Family,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });


            return true;
        }
    }
}
