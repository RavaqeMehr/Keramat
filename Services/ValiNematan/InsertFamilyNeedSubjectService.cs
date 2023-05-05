using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyNeedSubjectService : IScopedDependency {
        Task<int> Exe(InsertFamilyNeedSubjectDto dto);
    }

    public class InsertFamilyNeedSubjectService : IInsertFamilyNeedSubjectService {
        private readonly IRepository<FamilyNeedSubject> familyNeedSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyNeedSubjectService(
            IRepository<FamilyNeedSubject> familyNeedSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyNeedSubjectDto dto) {
            var item = dto.Adapt<FamilyNeedSubject>();
            await familyNeedSubjectRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeedSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeedSubject,
                EnitityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
