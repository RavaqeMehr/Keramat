using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IReOrderFamilyMemberNeedService : IScopedDependency {
        Task<bool> Exe(ReOrderDto dto);
    }

    public class ReOrderFamilyMemberNeedService : IReOrderFamilyMemberNeedService {
        private readonly IRepository<FamilyMemberNeed> familyMemberNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public ReOrderFamilyMemberNeedService(
            IRepository<FamilyMemberNeed> familyMemberNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberNeedRepo = familyMemberNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(ReOrderDto dto) {
            if (dto.SortedIds.Count() > 0) {
                var items = await familyMemberNeedRepo.TableNoTracking
                .Where(x => dto.SortedIds.Contains(x.Id))
                .ToListAsync();

                var allNotFromSameFamily = items.Any(x => x.FamilyMemberId != items[0].FamilyMemberId);
                if (allNotFromSameFamily) {
                    throw new Exception("!");
                }

                foreach (var item in items) {
                    var item_ = item.Clone();

                    item.Order = dto.SortedIds.ToList().IndexOf(item.Id) + 1;
                    await familyMemberNeedRepo.UpdateAsync(item);

                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeed> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeed,
                        Root2Id = item.FamilyId,
                        Root1Id = item.FamilyMemberId,
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
