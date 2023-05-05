using Common;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;

namespace Services.ValiNematan {
    public interface IGetFamilyNeedSubjectsListService : IScopedDependency {
        Task<List<FamilyNeedSubject>> Exe();
    }

    public class GetFamilyNeedSubjectsListService : IGetFamilyNeedSubjectsListService {
        private readonly IRepository<FamilyNeedSubject> familyNeedSubjectRepo;

        public GetFamilyNeedSubjectsListService(
            IRepository<FamilyNeedSubject> familyNeedSubjectRepo
            ) {
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
        }

        public async Task<List<FamilyNeedSubject>> Exe() {
            return await familyNeedSubjectRepo.TableNoTracking
                .OrderBy(x => x.Title)
                .ToListAsync();
        }
    }
}
