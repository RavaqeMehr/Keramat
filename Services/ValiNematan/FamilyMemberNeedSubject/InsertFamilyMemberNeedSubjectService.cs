using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyMemberNeedSubjectService : IScopedDependency {
        Task<int> Exe(InsertFamilyMemberNeedSubjectDto dto);
    }

    public class InsertFamilyMemberNeedSubjectService : IInsertFamilyMemberNeedSubjectService {
        private readonly IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyMemberNeedSubjectService(
            IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyMemberNeedSubjectDto dto) {
            var item = dto.Adapt<FamilyMemberNeedSubject>();
            await familyNeedSubjectRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeedSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeedSubject,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
