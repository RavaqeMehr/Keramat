using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.Kheyrat {
    public interface IRemoveKheyrService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveKheyrService : IRemoveKheyrService {
        private readonly IRepository<NikooKar> nikooKarRepo;
        private readonly IRepository<Kheyr> kheyrRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveKheyrService(
            IRepository<NikooKar> nikooKarRepo,
            IRepository<Kheyr> kheyrRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.nikooKarRepo = nikooKarRepo;
            this.kheyrRepo = kheyrRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await kheyrRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await kheyrRepo.DeleteAsync(item);

            var nikooKar = await nikooKarRepo.TableNoTracking
                .SingleAsync(x => x.Id == item.NikooKarId);

            nikooKar.KheyratCount = await kheyrRepo.TableNoTracking
                .CountAsync(x => x.NikooKarId == nikooKar.Id);
            await nikooKarRepo.UpdateAsync(nikooKar);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Kheyr> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.Kheyr,
                Root1Id = item.NikooKarId,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
