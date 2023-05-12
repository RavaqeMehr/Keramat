using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.Kheyrat {
    public interface IRemoveNikooKarService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveNikooKarService : IRemoveNikooKarService {
        private readonly IRepository<NikooKar> nikooKarRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveNikooKarService(
            IRepository<NikooKar> nikooKarRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.nikooKarRepo = nikooKarRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await nikooKarRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await nikooKarRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<NikooKar> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.NikooKar,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
