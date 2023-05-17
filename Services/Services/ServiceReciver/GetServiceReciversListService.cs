using Common;
using Data;
using Entities.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.Services.Models;

namespace Services.Services {
    public interface IGetServiceReciversListService : IScopedDependency {
        Task<WithPagination<ServiceReciverGetListItemDto>> Exe(GetListQuery query);
    }

    public class GetServiceReciversListService : IGetServiceReciversListService {
        private readonly IRepository<ServiceReciver> serviceReciverRepo;

        public GetServiceReciversListService(
            IRepository<ServiceReciver> serviceReciverRepo
            ) {
            this.serviceReciverRepo = serviceReciverRepo;
        }

        public async Task<WithPagination<ServiceReciverGetListItemDto>> Exe(GetListQuery query) {
            IQueryable<ServiceReciver> listAll = serviceReciverRepo.TableNoTracking
                .Include(x => x.Family)
                .Where(x => x.ServiceProvidedId == query.Id);

            var p = query.Page ?? 1;
            var perPage = 10;

            var output = new WithPagination<ServiceReciverGetListItemDto>();
            await output.Fill(listAll, p, perPage);
            var items = await listAll
                .OrderByDescending(x => x.Id)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            output.Items = items.Select(x => {
                var dto = x.Adapt<ServiceReciverGetListItemDto>();
                dto.FamilyTitle = x.Family.Title;
                return dto;
            }).ToList();

            return output;
        }
    }
}
