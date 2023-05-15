using Common;
using Data;
using Entities.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.Services.Models;

namespace Services.Services {
    public interface IGetServiceProvidedListByFamilyService : IScopedDependency {
        Task<WithPagination<ServiceProvidedGetListByFamilyItemDto>> Exe(GetListQuery query);
    }

    public class GetServiceProvidedListByFamilyService : IGetServiceProvidedListByFamilyService {
        private readonly IRepository<ServiceReciver> serviceReciverRepo;

        public GetServiceProvidedListByFamilyService(
            IRepository<ServiceReciver> serviceReciverRepo
            ) {
            this.serviceReciverRepo = serviceReciverRepo;
        }

        public async Task<WithPagination<ServiceProvidedGetListByFamilyItemDto>> Exe(GetListQuery query) {
            IQueryable<ServiceReciver> listAll = serviceReciverRepo.TableNoTracking
               .Include(x => x.ServiceProvided).ThenInclude(x => x.ServiceSubject);

            var p = query.Page ?? 1;
            var perPage = 10;

            var output = new WithPagination<ServiceProvidedGetListByFamilyItemDto>();
            await output.Fill(listAll, p, perPage);
            var items = await listAll
                .OrderByDescending(x => x.Id)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            output.Items = items.Select(x => {
                var dto = x.Adapt<ServiceProvidedGetListByFamilyItemDto>();
                dto.ServiceSubjectId = x.ServiceProvided.ServiceSubject.Id;
                dto.ServiceSubjectTitle = x.ServiceProvided.ServiceSubject.Title;
                dto.ServiceProvidedId = x.ServiceProvided.Id;
                dto.ServiceProvidedDescription = x.ServiceProvided.Description;
                dto.Date = x.ServiceProvided.Date;
                return dto;
            }).ToList();

            return output;
        }
    }
}
