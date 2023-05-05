using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IUpdateConnectorService : IScopedDependency {
        Task<bool> Exe(UpdateConnectorDto dto);
    }

    public class UpdateConnectorService : IUpdateConnectorService {
        private readonly IRepository<Connector> connectorRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateConnectorService(
            IRepository<Connector> connectorRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.connectorRepo = connectorRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(UpdateConnectorDto dto) {
            var item = await connectorRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Name = dto.Name;
            item.Phone = dto.Phone;
            item.Description = dto.Description;

            await connectorRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Connector> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.Connector,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
