using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyNeedSubjectUsesListService : IScopedDependency {
        Task<WithPagination<GetUsesListFamilyItemDto>> Exe(GetListQuery query);
    }

    public class GetFamilyNeedSubjectUsesListService : IGetFamilyNeedSubjectUsesListService {
        private readonly IRepository<Family> familyRepo;

        public GetFamilyNeedSubjectUsesListService(
            IRepository<Family> familyRepo
            ) {
            this.familyRepo = familyRepo;
        }

        public async Task<WithPagination<GetUsesListFamilyItemDto>> Exe(GetListQuery query) {
            var p = query.Page ?? 1;

            IQueryable<Family> listAll = familyRepo.TableNoTracking
                .Include(x => x.Needs)
                .Where(x => x.Needs.Any(y => y.FamilyNeedSubjectId == query.Id));

            var perPage = 10;

            var output = new WithPagination<GetUsesListFamilyItemDto>();
            await output.Fill(listAll, p, perPage);
            output.Items = await listAll
                .OrderBy(x => x.Title).ThenByDescending(x => x.AddDate)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .Select(x => new GetUsesListFamilyItemDto {
                    Id = x.Id,
                    Title = x.Title,
                    AddDate = x.AddDate.ToPersianDateString()
                })
                .ToListAsync();

            return output;
        }
    }
}
