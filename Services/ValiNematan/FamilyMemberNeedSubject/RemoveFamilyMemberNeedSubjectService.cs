using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyMemberNeedSubjectService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyMemberNeedSubjectService : IRemoveFamilyMemberNeedSubjectService {
        private readonly IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyMemberNeedSubjectService(
            IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyNeedSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyNeedSubjectRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeedSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeedSubject,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
