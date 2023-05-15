using Common;
using Data;
using Entities.Services;
using Mapster;
using Services.AppUsingLogs;
using Services.Services.Models;

namespace Services.Services {
    public interface IInsertServiceReciverService : IScopedDependency {
        Task<int> Exe(ServiceReciverInsertDto dto);
    }

    public class InsertServiceReciverService : IInsertServiceReciverService {
        private readonly IRepository<ServiceReciver> serviceReciverRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertServiceReciverService(
            IRepository<ServiceReciver> serviceReciverRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceReciverRepo = serviceReciverRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(ServiceReciverInsertDto dto) {
            var item = dto.Adapt<ServiceReciver>();

            await serviceReciverRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceReciver> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceReciver,
                Root2Id = item.FamilyId,
                Root1Id = item.ServiceProvidedId,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
