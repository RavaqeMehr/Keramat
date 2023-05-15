using Common;
using Common.Utilities;
using Data;
using Entities.Services;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.Services {
    public interface IRemoveServiceReciverService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveServiceReciverService : IRemoveServiceReciverService {
        private readonly IRepository<ServiceReciver> serviceReciverRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveServiceReciverService(
            IRepository<ServiceReciver> serviceReciverRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceReciverRepo = serviceReciverRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await serviceReciverRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await serviceReciverRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceReciver> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceReciver,
                Root2Id = item.FamilyId,
                Root1Id = item.ServiceProvidedId,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
