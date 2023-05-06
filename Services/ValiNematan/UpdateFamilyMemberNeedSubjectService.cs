using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IUpdateFamilyMemberNeedSubjectService : IScopedDependency {
        Task<bool> Exe(FamilyMemberNeedSubject dto);
    }

    public class UpdateFamilyMemberNeedSubjectService : IUpdateFamilyMemberNeedSubjectService {
        private readonly IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyMemberNeedSubjectService(
            IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(FamilyMemberNeedSubject dto) {
            var item = await familyNeedSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Title = dto.Title;
            item.Description = dto.Description;

            await familyNeedSubjectRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeedSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeedSubject,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
