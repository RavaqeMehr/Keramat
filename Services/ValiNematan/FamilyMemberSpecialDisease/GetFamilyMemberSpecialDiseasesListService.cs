using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyMemberSpecialDiseasesListService : IScopedDependency {
        Task<List<GetFamilyMemberSpecialDiseasesListItemDto>> Exe(int familyMemberId);
    }

    public class GetFamilyMemberSpecialDiseasesListService : IGetFamilyMemberSpecialDiseasesListService {
        private readonly IRepository<FamilyMember> familyMemberRepo;

        public GetFamilyMemberSpecialDiseasesListService(
            IRepository<FamilyMember> familyMemberRepo
            ) {
            this.familyMemberRepo = familyMemberRepo;
        }

        public async Task<List<GetFamilyMemberSpecialDiseasesListItemDto>> Exe(int familyMemberId) {
            var familyMember = await familyMemberRepo.TableNoTracking
               .Include(x => x.SpecialDiseases)
               .SingleAsync(x => x.Id == familyMemberId);

            return familyMember.SpecialDiseases
                .OrderBy(x => x.Order)
                .Select(x => x.Adapt<GetFamilyMemberSpecialDiseasesListItemDto>())
                .ToList();
        }
    }
}
