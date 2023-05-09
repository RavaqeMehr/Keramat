using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IUpdateFamilyNeedSubjectService : IScopedDependency {
        Task<bool> Exe(FamilyNeedSubject dto);
    }

    public class UpdateFamilyNeedSubjectService : IUpdateFamilyNeedSubjectService {
        private readonly IRepository<FamilyNeedSubject> familyNeedSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyNeedSubjectService(
            IRepository<FamilyNeedSubject> familyNeedSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(FamilyNeedSubject dto) {
            var item = await familyNeedSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Title = dto.Title;
            item.Description = dto.Description;

            await familyNeedSubjectRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeedSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeedSubject,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
