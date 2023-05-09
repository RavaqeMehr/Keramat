using Common;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;

namespace Services.ValiNematan {
    public interface IGetFamilyMemberRelationsListService : IScopedDependency {
        Task<List<FamilyMemberRelation>> Exe();
    }

    public class GetFamilyMemberRelationsListService : IGetFamilyMemberRelationsListService {
        private readonly IRepository<FamilyMemberRelation> familyRelationRepo;

        public GetFamilyMemberRelationsListService(
            IRepository<FamilyMemberRelation> familyRelationRepo
            ) {
            this.familyRelationRepo = familyRelationRepo;
        }

        public async Task<List<FamilyMemberRelation>> Exe() {
            return await familyRelationRepo.TableNoTracking
                .OrderBy(x => x.Order)
                .ToListAsync();
        }
    }
}
