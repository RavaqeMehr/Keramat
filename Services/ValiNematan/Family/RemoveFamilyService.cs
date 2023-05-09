using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyService : IRemoveFamilyService {
        private readonly IRepository<Family> familyRepo;
        private readonly IRepository<FamilyNeed> familyNeedRepo;
        private readonly IRepository<FamilyMember> familyMemberRepo;
        private readonly IRepository<FamilyMemberNeed> familyMemberNeedRepo;
        private readonly IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyService(
            IRepository<Family> familyRepo,
            IRepository<FamilyNeed> familyNeedRepo,
            IRepository<FamilyMember> familyMemberRepo,
            IRepository<FamilyMemberNeed> familyMemberNeedRepo,
            IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyRepo = familyRepo;
            this.familyNeedRepo = familyNeedRepo;
            this.familyMemberRepo = familyMemberRepo;
            this.familyMemberNeedRepo = familyMemberNeedRepo;
            this.familyMemberSpecialDiseaseRepo = familyMemberSpecialDiseaseRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyRepo.TableNoTracking
                .Include(x => x.Needs)
                .Include(x => x.Members).ThenInclude(x => x.Needs)
                .Include(x => x.Members).ThenInclude(x => x.SpecialDiseases)
                .FirstAsync(x => x.Id == id);
            var item_ = item.Clone();


            if (item.Needs.Count > 0) {
                foreach (var subItem in item.Needs) {
                    var subItem_ = subItem.Clone();
                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeed> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeed,
                        EnitityId = subItem.Id,
                        ObjA = subItem_,
                    });
                }
                await familyNeedRepo.DeleteRangeAsync(item.Needs);
            }

            if (item.Members.Count > 0) {
                foreach (var subItem in item.Members) {
                    if (subItem.Needs.Count > 0) {
                        foreach (var subSubItem in subItem.Needs) {
                            var subSubItem_ = subSubItem.Clone();
                            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeed> {
                                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeed,
                                Root2Id = subItem.FamilyId,
                                Root1Id = subItem.Id,
                                EnitityId = subSubItem.Id,
                                ObjA = subSubItem_,
                            });
                        }
                        await familyMemberNeedRepo.DeleteRangeAsync(subItem.Needs);
                    }

                    if (subItem.SpecialDiseases.Count > 0) {
                        foreach (var subSubItem in subItem.SpecialDiseases) {
                            var subSubItem_ = subSubItem.Clone();
                            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDisease> {
                                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDisease,
                                Root2Id = subItem.FamilyId,
                                Root1Id = subItem.Id,
                                EnitityId = subSubItem.Id,
                                ObjA = subSubItem_,
                            });
                        }
                        await familyMemberSpecialDiseaseRepo.DeleteRangeAsync(subItem.SpecialDiseases);
                    }

                    var subItem_ = subItem.Clone();
                    await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMember> {
                        ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                        EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMember,
                        Root1Id = subItem.FamilyId,
                        EnitityId = subItem.Id,
                        ObjA = subItem_,
                    });
                }
                await familyMemberRepo.DeleteRangeAsync(item.Members);
            }


            await familyRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<Family> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.Family,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
