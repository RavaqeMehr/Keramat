using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyNeedsListService : IScopedDependency {
        Task<List<GetFamilyNeedsListItemDto>> Exe(int familyId);
    }

    public class GetFamilyNeedsListService : IGetFamilyNeedsListService {
        private readonly IRepository<Family> familyRepo;

        public GetFamilyNeedsListService(
            IRepository<Family> familyRepo
            ) {
            this.familyRepo = familyRepo;
        }

        public async Task<List<GetFamilyNeedsListItemDto>> Exe(int familyId) {

            var family = await familyRepo.TableNoTracking
                .Include(x => x.Needs)
                .SingleAsync(x => x.Id == familyId);

            return family.Needs
                .OrderBy(x => x.Order)
                .Select(x => x.Adapt<GetFamilyNeedsListItemDto>())
                .ToList();
        }
    }
}
