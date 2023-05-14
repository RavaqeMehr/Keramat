using Common;
using Common.Utilities;
using Data;
using Entities.Services;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.Services {
    public interface IRemoveServiceSubjectService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveServiceSubjectService : IRemoveServiceSubjectService {
        private readonly IRepository<ServiceSubject> serviceSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveServiceSubjectService(
            IRepository<ServiceSubject> serviceSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceSubjectRepo = serviceSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await serviceSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await serviceSubjectRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceSubject,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
