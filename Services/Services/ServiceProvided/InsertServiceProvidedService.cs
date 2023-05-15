using Common;
using Common.Utilities;
using Data;
using Entities.Services;
using Mapster;
using Services.AppUsingLogs;
using Services.Services.Models;

namespace Services.Services {
    public interface IInsertServiceProvidedService : IScopedDependency {
        Task<int> Exe(ServiceProvidedDto dto);
    }

    public class InsertServiceProvidedService : IInsertServiceProvidedService {
        private readonly IRepository<ServiceProvided> serviceProvidedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertServiceProvidedService(
            IRepository<ServiceProvided> serviceProvidedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.serviceProvidedRepo = serviceProvidedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }


        public async Task<int> Exe(ServiceProvidedDto dto) {
            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();

            var item = dto.Adapt<ServiceProvided>();

            item.Date = now;
            item.DateY = nowFa.Year;
            item.DateM = nowFa.Month;
            item.DateD = nowFa.Day;
            await serviceProvidedRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<ServiceProvided> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.ServiceProvided,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
