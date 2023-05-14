using Common;
using Common.Utilities;
using Data;
using Entities.Services;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.Services {
    public interface IUpdateServiceSubjectService : IScopedDependency {
        Task<bool> Exe(ServiceSubject dto);

    }

    public class UpdateServiceSubjectService : IUpdateServiceSubjectService {
        private readonly IRepository<ServiceSubject> serviceSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateServiceSubjectService(
            IRepository<ServiceSubject> serviceSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceSubjectRepo = serviceSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(ServiceSubject dto) {
            var item = await serviceSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Title = dto.Title;
            item.Description = dto.Description;

            await serviceSubjectRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceSubject,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
