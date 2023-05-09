using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IReOrderFamilyMemberSpecialDiseaseService : IScopedDependency {
        Task<bool> Exe(ReOrderDto dto);
    }

    public class ReOrderFamilyMemberSpecialDiseaseService : IReOrderFamilyMemberSpecialDiseaseService {
        private readonly IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public ReOrderFamilyMemberSpecialDiseaseService(
            IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberSpecialDiseaseRepo = familyMemberSpecialDiseaseRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(ReOrderDto dto) {
            if (dto.SortedIds.Count() > 0) {
                var items = await familyMemberSpecialDiseaseRepo.TableNoTracking
                .Where(x => dto.SortedIds.Contains(x.Id))
                .ToListAsync();

                var allNotFromSameFamily = items.Any(x => x.FamilyMemberId != items[0].FamilyMemberId);
                if (allNotFromSameFamily) {
                    throw new Exception("!");
                }

                foreach (var item in items) {
                    var item_ = item.Clone();

                    item.Order = dto.SortedIds.ToList().IndexOf(item.Id) + 1;
                    await familyMemberSpecialDiseaseRepo.UpdateAsync(item);

                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDisease> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDisease,
                        Root2Id = item.FamilyId,
                        Root1Id = item.FamilyMemberId,
                        EnitityId = item.Id,
                        ObjA = item_,
                        ObjB = item
                    });
                }
            }

            return true;
        }
    }
}
