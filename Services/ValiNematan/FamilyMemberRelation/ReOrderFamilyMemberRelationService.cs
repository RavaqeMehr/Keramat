using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IReOrderFamilyMemberRelationService : IScopedDependency {
        Task<bool> Exe(ReOrderFamilyMemberRelationDto dto);
    }

    public class ReOrderFamilyMemberRelationService : IReOrderFamilyMemberRelationService {
        private readonly IRepository<FamilyMemberRelation> familyMemberRelationRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public ReOrderFamilyMemberRelationService(
            IRepository<FamilyMemberRelation> familyMemberRelationRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberRelationRepo = familyMemberRelationRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(ReOrderFamilyMemberRelationDto dto) {
            if (dto.SortedIds.Count() > 0) {
                var items = await familyMemberRelationRepo.TableNoTracking
                .Where(x => dto.SortedIds.Contains(x.Id))
                .ToListAsync();

                foreach (var item in items) {
                    var item_ = item.Clone();

                    item.Order = dto.SortedIds.ToList().IndexOf(item.Id) + 1;
                    await familyMemberRelationRepo.UpdateAsync(item);

                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberRelation> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberRelation,
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
