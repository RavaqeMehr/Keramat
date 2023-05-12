using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IInsertKheyrService : IScopedDependency {
        Task<int> Exe(KheyrInsertDto dto);
    }

    public class InsertKheyrService : IInsertKheyrService {
        private readonly IRepository<NikooKar> nikooKarRepo;
        private readonly IRepository<Kheyr> kheyrRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertKheyrService(
            IRepository<NikooKar> nikooKarRepo,
            IRepository<Kheyr> kheyrRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.nikooKarRepo = nikooKarRepo;
            this.kheyrRepo = kheyrRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(KheyrInsertDto dto) {
            var nikooKar = await nikooKarRepo.TableNoTracking
                .SingleAsync(x => x.Id == dto.NikooKarId);

            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();

            var item = dto.Adapt<Kheyr>();

            item.Date = now;
            item.DateY = nowFa.Year;
            item.DateM = nowFa.Month;
            item.DateD = nowFa.Day;

            item.HasCash = dto.CashValue > 0;
            item.HasNotCash = dto.NotCashValue > 0;
            item.CashValue = Math.Max(0, dto.CashValue);
            item.NotCashValue = Math.Max(0, dto.NotCashValue);
            item.CashAndNotCashValues = item.CashValue + item.NotCashValue;

            await kheyrRepo.AddAsync(item);

            nikooKar.KheyratCount = await kheyrRepo.TableNoTracking
                .CountAsync(x => x.NikooKarId == nikooKar.Id);
            await nikooKarRepo.UpdateAsync(nikooKar);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Kheyr> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.Kheyr,
                Root1Id = nikooKar.Id,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
