using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyLevelUsesListService : IScopedDependency {
        Task<WithPagination<GetFamilyLevelUsesListItemDto>> Exe(GetFamilyLevelUsesListQuery query);
    }

    public class GetFamilyLevelUsesListService : IGetFamilyLevelUsesListService {
        private readonly IRepository<Family> familyRepo;

        public GetFamilyLevelUsesListService(
            IRepository<Family> familyRepo
            ) {
            this.familyRepo = familyRepo;
        }

        public async Task<WithPagination<GetFamilyLevelUsesListItemDto>> Exe(GetFamilyLevelUsesListQuery query) {
            var p = query.Page ?? 1;

            IQueryable<Family> listAll = familyRepo.TableNoTracking
               .Where(x => x.LevelId == query.Id);

            var perPage = 10;

            var output = new WithPagination<GetFamilyLevelUsesListItemDto>();
            await output.Fill(listAll, p, perPage);
            output.Items = await listAll
                .OrderBy(x => x.Title).ThenByDescending(x => x.AddDate)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .Select(x => new GetFamilyLevelUsesListItemDto {
                    Id = x.Id,
                    Title = x.Title,
                    AddDate = x.AddDate.ToPersianDateString()
                })
                .ToListAsync();

            return output;
        }
    }
}
