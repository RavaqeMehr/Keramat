using Common;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;

namespace Services.ValiNematan {
    public interface IGetFamilyMemberSpecialDiseaseSubjectsListService : IScopedDependency {
        Task<List<FamilyMemberSpecialDiseaseSubject>> Exe();
    }

    public class GetFamilyMemberSpecialDiseaseSubjectsListService : IGetFamilyMemberSpecialDiseaseSubjectsListService {
        private readonly IRepository<FamilyMemberSpecialDiseaseSubject> familySpecialDiseaseSubjectRepo;

        public GetFamilyMemberSpecialDiseaseSubjectsListService(
            IRepository<FamilyMemberSpecialDiseaseSubject> familySpecialDiseaseSubjectRepo
            ) {
            this.familySpecialDiseaseSubjectRepo = familySpecialDiseaseSubjectRepo;
        }

        public async Task<List<FamilyMemberSpecialDiseaseSubject>> Exe() {
            return await familySpecialDiseaseSubjectRepo.TableNoTracking
                .OrderBy(x => x.Title)
                .ToListAsync();
        }
    }
}
