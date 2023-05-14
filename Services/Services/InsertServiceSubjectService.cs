using Common;
using Data;
using Entities.Services;
using Mapster;
using Services.AppUsingLogs;
using Services.Services.Models;

namespace Services.Services {
    public interface IInsertServiceSubjectService : IScopedDependency {
        Task<int> Exe(ServiceSubjectInsertDto dto);
    }

    public class InsertServiceSubjectService : IInsertServiceSubjectService {
        private readonly IRepository<ServiceSubject> serviceSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertServiceSubjectService(
            IRepository<ServiceSubject> serviceSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceSubjectRepo = serviceSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(ServiceSubjectInsertDto dto) {
            var item = dto.Adapt<ServiceSubject>();
            await serviceSubjectRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceSubject,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
