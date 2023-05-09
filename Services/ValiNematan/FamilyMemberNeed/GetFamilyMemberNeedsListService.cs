using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyMemberNeedsListService : IScopedDependency {
        Task<List<GetFamilyMemberNeedsListItemDto>> Exe(int familyMemberId);
    }

    public class GetFamilyMemberNeedsListService : IGetFamilyMemberNeedsListService {
        private readonly IRepository<FamilyMember> familyMemberRepo;

        public GetFamilyMemberNeedsListService(
            IRepository<FamilyMember> familyMemberRepo
            ) {
            this.familyMemberRepo = familyMemberRepo;
        }

        public async Task<List<GetFamilyMemberNeedsListItemDto>> Exe(int familyMemberId) {
            var familyMember = await familyMemberRepo.TableNoTracking
               .Include(x => x.Needs)
               .SingleAsync(x => x.Id == familyMemberId);

            return familyMember.Needs
                .OrderBy(x => x.Order)
                .Select(x => x.Adapt<GetFamilyMemberNeedsListItemDto>())
                .ToList();
        }
    }
}
