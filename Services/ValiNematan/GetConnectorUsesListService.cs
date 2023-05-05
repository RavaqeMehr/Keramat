using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetConnectorUsesListService : IScopedDependency {
        Task<WithPagination<GetConnectorUsesListItemDto>> Exe(GetConnectorUsesListQuery query);
    }

    public class GetConnectorUsesListService : IGetConnectorUsesListService {
        private readonly IRepository<Family> familyRepo;

        public GetConnectorUsesListService(
            IRepository<Family> familyRepo
            ) {
            this.familyRepo = familyRepo;
        }

        public async Task<WithPagination<GetConnectorUsesListItemDto>> Exe(GetConnectorUsesListQuery query) {
            var p = query.Page ?? 1;

            IQueryable<Family> listAll = familyRepo.TableNoTracking
               .Where(x => x.ConnectorId == query.Id);

            var perPage = 10;

            var output = new WithPagination<GetConnectorUsesListItemDto>();
            await output.Fill(listAll, p, perPage);
            output.Items = await listAll
                .OrderBy(x => x.Title).ThenByDescending(x => x.AddDate)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .Select(x => new GetConnectorUsesListItemDto {
                    Id = x.Id,
                    Title = x.Title,
                    AddDate = x.AddDate.ToPersianDateString()
                })
                .ToListAsync();

            return output;
        }
    }
}
