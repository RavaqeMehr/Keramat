using Common;
using Data;
using Entities.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Services.Models;

namespace Services.Services {
    public interface IGetServiceProvidedByIdService : IScopedDependency {
        Task<ServiceProvidedDto> Exe(int id);
    }

    public class GetServiceProvidedByIdService : IGetServiceProvidedByIdService {
        private readonly IRepository<ServiceProvided> serviceProvidedRepo;

        public GetServiceProvidedByIdService(
            IRepository<ServiceProvided> serviceProvidedRepo
            ) {
            this.serviceProvidedRepo = serviceProvidedRepo;
        }

        public async Task<ServiceProvidedDto> Exe(int id) {
            var item = await serviceProvidedRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            return item.Adapt<ServiceProvidedDto>();
        }
    }
}
