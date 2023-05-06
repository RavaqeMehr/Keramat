using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyMemberSpecialDiseaseSubjectService : IScopedDependency {
        Task<int> Exe(InsertFamilyMemberSpecialDiseaseSubjectDto dto);
    }

    public class InsertFamilyMemberSpecialDiseaseSubjectService : IInsertFamilyMemberSpecialDiseaseSubjectService {
        private readonly IRepository<FamilyMemberSpecialDiseaseSubject> familySpecialDiseaseSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyMemberSpecialDiseaseSubjectService(
            IRepository<FamilyMemberSpecialDiseaseSubject> familySpecialDiseaseSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familySpecialDiseaseSubjectRepo = familySpecialDiseaseSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyMemberSpecialDiseaseSubjectDto dto) {
            var item = dto.Adapt<FamilyMemberSpecialDiseaseSubject>();
            await familySpecialDiseaseSubjectRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDiseaseSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDiseaseSubject,
                EnitityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
