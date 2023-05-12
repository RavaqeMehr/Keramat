using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IUpdateNikooKarService : IScopedDependency {
        Task<bool> Exe(NikooKarUpdateDto dto);
    }

    public class UpdateNikooKarService : IUpdateNikooKarService {
        private readonly IRepository<NikooKar> nikooKarRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateNikooKarService(
            IRepository<NikooKar> nikooKarRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.nikooKarRepo = nikooKarRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(NikooKarUpdateDto dto) {
            var item = await nikooKarRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.FullName = dto.FullName;
            item.Phone = dto.Phone;
            item.Address = dto.Address;
            item.Description = dto.Description;
            item.Job = dto.Job;
            item.JobDescription = dto.JobDescription;
            item.JobAddress = dto.JobAddress;
            item.JobPhone = dto.JobPhone;

            await nikooKarRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<NikooKar> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.NikooKar,
                EntityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
