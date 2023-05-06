using Common;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;

namespace Services.ValiNematan {
    public interface IGetFamilyMemberNeedSubjectsListService : IScopedDependency {
        Task<List<FamilyMemberNeedSubject>> Exe();
    }

    public class GetFamilyMemberNeedSubjectsListService : IGetFamilyMemberNeedSubjectsListService {
        private readonly IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo;

        public GetFamilyMemberNeedSubjectsListService(
            IRepository<FamilyMemberNeedSubject> familyNeedSubjectRepo
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
        }

        public async Task<List<FamilyMemberNeedSubject>> Exe() {
            return await familyNeedSubjectRepo.TableNoTracking
                .OrderBy(x => x.Title)
                .ToListAsync();
        }
    }
}
