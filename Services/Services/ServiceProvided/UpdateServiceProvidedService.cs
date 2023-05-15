using Common;
using Common.Utilities;
using Data;
using Entities.Services;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.Services.Models;

namespace Services.Services {
    public interface IUpdateServiceProvidedService : IScopedDependency {
        Task<bool> Exe(ServiceProvidedUpdateDto dto);
    }

    public class UpdateServiceProvidedService : IUpdateServiceProvidedService {
        private readonly IRepository<ServiceProvided> serviceProvidedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateServiceProvidedService(
            IRepository<ServiceProvided> serviceProvidedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceProvidedRepo = serviceProvidedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(ServiceProvidedUpdateDto dto) {
            var item = await serviceProvidedRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.ServiceSubjectId = dto.ServiceSubjectId;
            item.Description = dto.Description;

            await serviceProvidedRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceProvided> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceProvided,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
