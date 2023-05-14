using Common;
using Data;
using Entities.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.Services.Models;

namespace Services.Services {
    public interface IGetServiceSubjectUsesListService : IScopedDependency {
        Task<WithPagination<ServiceSubjectGetUsesListItemDto>> Exe(GetUsesListQuery query);
    }

    public class GetServiceSubjectUsesListService : IGetServiceSubjectUsesListService {
        private readonly IRepository<ServiceProvided> serviceProvidedRepo;

        public GetServiceSubjectUsesListService(
            IRepository<ServiceProvided> serviceProvidedRepo
            ) {
            this.serviceProvidedRepo = serviceProvidedRepo;
        }

        public async Task<WithPagination<ServiceSubjectGetUsesListItemDto>> Exe(GetUsesListQuery query) {
            var p = query.Page ?? 1;

            IQueryable<ServiceProvided> listAll = serviceProvidedRepo.TableNoTracking
                .Include(x => x.ServiceSubject)
                .Where(x => x.ServiceSubjectId == query.Id);

            var perPage = 10;

            var output = new WithPagination<ServiceSubjectGetUsesListItemDto>();
            await output.Fill(listAll, p, perPage);
            var items = await listAll
                .OrderByDescending(x => x.Date)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            output.Items = items.Select(x => {
                var dto = x.Adapt<ServiceSubjectGetUsesListItemDto>();
                dto.ServiceSubjectTitle = x.ServiceSubject.Title;
                return dto;
            }).ToList();

            return output;
        }
    }
}
