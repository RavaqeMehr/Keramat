using Common;
using Data;
using Entities.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.Services.Models;

namespace Services.Services {
    public interface IGetServiceProvidedsListService : IScopedDependency {
        Task<WithPagination<ServiceProvidedGetListItemDto>> Exe(int page);
    }

    public class GetServiceProvidedsListService : IGetServiceProvidedsListService {
        private readonly IRepository<ServiceProvided> serviceProvidedRepo;

        public GetServiceProvidedsListService(
            IRepository<ServiceProvided> serviceProvidedRepo
            ) {
            this.serviceProvidedRepo = serviceProvidedRepo;
        }

        public async Task<WithPagination<ServiceProvidedGetListItemDto>> Exe(int page) {
            IQueryable<ServiceProvided> listAll = serviceProvidedRepo.TableNoTracking
                .Include(x => x.ServiceSubject)
                .Include(x => x.Recivers);

            var perPage = 10;

            var output = new WithPagination<ServiceProvidedGetListItemDto>();
            await output.Fill(listAll, page, perPage);
            var items = await listAll
                .OrderByDescending(x => x.Date)
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            output.Items = items.Select(x => {
                var dto = x.Adapt<ServiceProvidedGetListItemDto>();
                dto.ServiceSubjectTitle = x.ServiceSubject.Title;
                dto.ReciversCount = x.Recivers.Count;
                return dto;
            }).ToList();

            return output;
        }
    }
}
