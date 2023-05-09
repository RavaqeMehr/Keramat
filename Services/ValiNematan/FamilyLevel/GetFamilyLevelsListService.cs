using Common;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;

namespace Services.ValiNematan {
    public interface IGetFamilyLevelsListService : IScopedDependency {
        Task<List<FamilyLevel>> Exe();
    }

    public class GetFamilyLevelsListService : IGetFamilyLevelsListService {
        private readonly IRepository<FamilyLevel> familyLevelRepo;

        public GetFamilyLevelsListService(
            IRepository<FamilyLevel> familyLevelRepo
            ) {
            this.familyLevelRepo = familyLevelRepo;
        }

        public async Task<List<FamilyLevel>> Exe() {
            return await familyLevelRepo.TableNoTracking
                .OrderBy(x => x.Level)
                .ToListAsync();
        }
    }
}
