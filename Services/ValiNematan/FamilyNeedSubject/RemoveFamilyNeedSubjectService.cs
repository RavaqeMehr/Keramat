using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyNeedSubjectService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyNeedSubjectService : IRemoveFamilyNeedSubjectService {
        private readonly IRepository<FamilyNeedSubject> familyNeedSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyNeedSubjectService(
            IRepository<FamilyNeedSubject> familyNeedSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyNeedSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyNeedSubjectRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeedSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeedSubject,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
