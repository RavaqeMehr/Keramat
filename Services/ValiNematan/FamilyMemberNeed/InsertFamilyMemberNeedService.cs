using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyMemberNeedService : IScopedDependency {
        Task<int> Exe(InsertFamilyMemberNeedDto dto);
    }

    public class InsertFamilyMemberNeedService : IInsertFamilyMemberNeedService {
        private readonly IRepository<FamilyMember> familyMemberRepo;
        private readonly IRepository<FamilyMemberNeed> familyMemberNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyMemberNeedService(
            IRepository<FamilyMember> familyMemberRepo,
            IRepository<FamilyMemberNeed> familyMemberNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberRepo = familyMemberRepo;
            this.familyMemberNeedRepo = familyMemberNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyMemberNeedDto dto) {
            var familyMember = await familyMemberRepo.TableNoTracking
               .Include(x => x.Needs)
               .SingleAsync(x => x.Id == dto.FamilyMemberId);

            if (familyMember.Needs.Any(x => x.FamilyMemberNeedSubjectId == dto.FamilyMemberNeedSubjectId)) {
                throw new Exception("این نیاز قبلا ثبت شده بود.");
            }

            var item = dto.Adapt<FamilyMemberNeed>();
            item.Order = familyMember.Needs.Count + 1;
            item.FamilyId = familyMember.FamilyId;
            await familyMemberNeedRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberNeed> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberNeed,
                Root2Id = familyMember.FamilyId,
                Root1Id = familyMember.Id,
                EnitityId = item.Id,
                ObjA = item,
            });

            return item.Id;
        }
    }
}
