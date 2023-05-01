using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetConnectorsListService : IScopedDependency {
        Task<List<GetConnectorsListItemDto>> Exe();
    }

    public class GetConnectorsListService : IGetConnectorsListService {
        private readonly IRepository<Connector> connectorRepo;

        public GetConnectorsListService(
            IRepository<Connector> connectorRepo
            ) {
            this.connectorRepo = connectorRepo;
        }

        public async Task<List<GetConnectorsListItemDto>> Exe() {
            return await connectorRepo.TableNoTracking
                .OrderBy(x => x.Name)
                .ProjectToType<GetConnectorsListItemDto>()
                .ToListAsync();
        }
    }
}
