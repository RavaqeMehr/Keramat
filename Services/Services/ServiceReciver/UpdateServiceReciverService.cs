using Common;
using Common.Utilities;
using Data;
using Entities.Services;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.Services.Models;

namespace Services.Services {
    public interface IUpdateServiceReciverService : IScopedDependency {
        Task<bool> Exe(ServiceReciverUpdateDto dto);
    }

    public class UpdateServiceReciverService : IUpdateServiceReciverService {
        private readonly IRepository<ServiceReciver> serviceReciverRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateServiceReciverService(
            IRepository<ServiceReciver> serviceReciverRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceReciverRepo = serviceReciverRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(ServiceReciverUpdateDto dto) {
            var item = await serviceReciverRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Description = dto.Description;

            await serviceReciverRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceReciver> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceReciver,
                Root2Id = item.FamilyId,
                Root1Id = item.ServiceProvidedId,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
