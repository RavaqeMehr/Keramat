using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Mapster;
using Services.AppUsingLogs;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IInsertNikooKarService : IScopedDependency {
        Task<int> Exe(NikooKarDto dto);
    }

    public class InsertNikooKarService : IInsertNikooKarService {
        private readonly IRepository<NikooKar> nikooKarRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertNikooKarService(
            IRepository<NikooKar> nikooKarRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.nikooKarRepo = nikooKarRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(NikooKarDto dto) {
            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();

            var item = dto.Adapt<NikooKar>();

            item.AddDate = now;
            item.AddDateY = nowFa.Year;
            item.AddDateM = nowFa.Month;
            item.AddDateD = nowFa.Day;

            await nikooKarRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<NikooKar> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.NikooKar,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
