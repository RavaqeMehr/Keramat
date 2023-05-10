using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IReOrderFamilyNeedService : IScopedDependency {
        Task<bool> Exe(ReOrderDto dto);
    }

    public class ReOrderFamilyNeedService : IReOrderFamilyNeedService {
        private readonly IRepository<FamilyNeed> familyNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public ReOrderFamilyNeedService(
            IRepository<FamilyNeed> familyNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyNeedRepo = familyNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(ReOrderDto dto) {
            if (dto.SortedIds.Count() > 0) {
                var items = await familyNeedRepo.TableNoTracking
                .Where(x => dto.SortedIds.Contains(x.Id))
                .ToListAsync();

                var allNotFromSameFamily = items.Any(x => x.FamilyId != items[0].FamilyId);
                if (allNotFromSameFamily) {
                    throw new Exception("!");
                }

                foreach (var item in items) {
                    var item_ = item.Clone();

                    item.Order = dto.SortedIds.ToList().IndexOf(item.Id) + 1;
                    await familyNeedRepo.UpdateAsync(item);

                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeed> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeed,
                        Root1Id = item.FamilyId,
                        EntityId = item.Id,
                        ObjA = item_,
                        ObjB = item
                    });
                }
            }

            return true;
        }
    }
}
