using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveConnectorService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveConnectorService : IRemoveConnectorService {
        private readonly IRepository<Connector> connectorRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveConnectorService(
            IRepository<Connector> connectorRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.connectorRepo = connectorRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await connectorRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await connectorRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Connector> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.Connector,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
