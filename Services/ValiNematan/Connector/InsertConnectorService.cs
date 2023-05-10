using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertConnectorService : IScopedDependency {
        Task<int> Exe(InsertConnectorDto dto);
    }

    public class InsertConnectorService : IInsertConnectorService {
        private readonly IRepository<Connector> connectorRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertConnectorService(
            IRepository<Connector> connectorRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.connectorRepo = connectorRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertConnectorDto dto) {
            var item = dto.Adapt<Connector>();
            await connectorRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Connector> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.Connector,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
