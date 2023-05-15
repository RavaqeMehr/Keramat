using Common;
using Common.Utilities;
using Data;
using Entities.Services;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.Services {
    public interface IRemoveServiceProvidedService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveServiceProvidedService : IRemoveServiceProvidedService {
        private readonly IRepository<ServiceProvided> serviceProvidedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveServiceProvidedService(
            IRepository<ServiceProvided> serviceProvidedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceProvidedRepo = serviceProvidedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await serviceProvidedRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await serviceProvidedRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceProvided> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceProvided,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
