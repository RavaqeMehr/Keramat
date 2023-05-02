using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyService : IScopedDependency {
        Task<int> Exe(InsertFamilyDto dto);
    }

    public class InsertFamilyService : IInsertFamilyService {
        private readonly IRepository<Family> familyRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyService(
            IRepository<Family> familyRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyRepo = familyRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyDto dto) {
            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();

            var item = dto.Adapt<Family>();

            item.AddDate = now;
            item.AddDateY = nowFa.Year;
            item.AddDateM = nowFa.Month;
            item.AddDateD = nowFa.Day;

            await familyRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Family> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.Family,
                EnitityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
