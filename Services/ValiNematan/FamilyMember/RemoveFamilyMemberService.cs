using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyMemberService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyMemberService : IRemoveFamilyMemberService {
        private readonly IRepository<FamilyMember> familyMemberRepo;
        private readonly IRepository<FamilyMemberNeed> familyMemberNeedRepo;
        private readonly IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyMemberService(
            IRepository<FamilyMember> familyMemberRepo,
            IRepository<FamilyMemberNeed> familyMemberNeedRepo,
            IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberRepo = familyMemberRepo;
            this.familyMemberNeedRepo = familyMemberNeedRepo;
            this.familyMemberSpecialDiseaseRepo = familyMemberSpecialDiseaseRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyMemberRepo.TableNoTracking
                .FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            if (item.Needs.Count > 0) {
                foreach (var subItem in item.Needs) {
                    var subItem_ = subItem.Clone();
                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeed> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeed,
                        Root2Id = item.FamilyId,
                        Root1Id = item.Id,
                        EntityId = subItem.Id,
                        ObjA = subItem_,
                    });
                }
                await familyMemberNeedRepo.DeleteRangeAsync(item.Needs);
            }

            if (item.SpecialDiseases.Count > 0) {
                foreach (var subItem in item.SpecialDiseases) {
                    var subItem_ = subItem.Clone();
                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDisease> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDisease,
                        Root2Id = item.FamilyId,
                        Root1Id = item.Id,
                        EntityId = subItem.Id,
                        ObjA = subItem_,
                    });
                }
                await familyMemberSpecialDiseaseRepo.DeleteRangeAsync(item.SpecialDiseases);
            }

            await familyMemberRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMember> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMember,
                Root1Id = item.FamilyId,
                EntityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
