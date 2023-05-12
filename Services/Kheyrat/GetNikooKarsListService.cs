using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IGetNikooKarsListService : IScopedDependency {
        Task<WithPagination<GetNikooKarsListItemDto>> Search(GetNikooKarsListQuery query);
    }

    public class GetNikooKarsListService : IGetNikooKarsListService {
        private readonly IRepository<NikooKar> nikooKarRepo;

        public GetNikooKarsListService(
            IRepository<NikooKar> nikooKarRepo
            ) {
            this.nikooKarRepo = nikooKarRepo;
        }

        public async Task<WithPagination<GetNikooKarsListItemDto>> Search(GetNikooKarsListQuery query) {
            var s = query.Search.GetStringValue();
            var p = query.Page ?? 1;

            IQueryable<NikooKar> listAll = nikooKarRepo.TableNoTracking;

            if (s.Length > 0) {
                listAll = listAll.Where(x =>
                x.FullName.Contains(s) ||
                x.Phone.Contains(s) ||
                x.Address.Contains(s) ||
                x.Description.Contains(s) ||
                x.Job.Contains(s) ||
                x.JobDescription.Contains(s) ||
                x.JobAddress.Contains(s) ||
                x.JobPhone.Contains(s)
                );
            }

            var perPage = 10;

            var output = new WithPagination<GetNikooKarsListItemDto>();
            await output.Fill(listAll, p, perPage);
            var items = await listAll
                .OrderBy(x => x.FullName).ThenByDescending(x => x.AddDate)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            output.Items = items.Select(x => {
                var dto = x.Adapt<GetNikooKarsListItemDto>();
                dto.AddDateStr = x.AddDate.ToPersianDateString();
                return dto;
            }).ToList();

            return output;
        }
    }
}
