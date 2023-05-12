using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IUpdateKheyrService : IScopedDependency {
        Task<bool> Exe(KheyrUpdateDto dto);
    }

    public class UpdateKheyrService : IUpdateKheyrService {
        private readonly IRepository<Kheyr> kheyrRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateKheyrService(
            IRepository<Kheyr> kheyrRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.kheyrRepo = kheyrRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(KheyrUpdateDto dto) {
            var item = await kheyrRepo.TableNoTracking
                .FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.HasCash = dto.CashValue > 0;
            item.HasNotCash = dto.NotCashValue > 0;
            item.CashValue = Math.Max(0, dto.CashValue);
            item.NotCashValue = Math.Max(0, dto.NotCashValue);
            item.CashAndNotCashValues = item.CashValue + item.NotCashValue;

            await kheyrRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Kheyr> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.Kheyr,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
