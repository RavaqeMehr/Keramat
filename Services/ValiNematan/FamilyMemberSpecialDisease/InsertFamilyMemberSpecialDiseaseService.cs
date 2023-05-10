using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyMemberSpecialDiseaseService : IScopedDependency {
        Task<int> Exe(InsertFamilyMemberSpecialDiseaseDto dto);
    }

    public class InsertFamilyMemberSpecialDiseaseService : IInsertFamilyMemberSpecialDiseaseService {
        private readonly IRepository<FamilyMember> familyMemberRepo;
        private readonly IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyMemberSpecialDiseaseService(
            IRepository<FamilyMember> familyMemberRepo,
            IRepository<FamilyMemberSpecialDisease> familyMemberSpecialDiseaseRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberRepo = familyMemberRepo;
            this.familyMemberSpecialDiseaseRepo = familyMemberSpecialDiseaseRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyMemberSpecialDiseaseDto dto) {
            var familyMember = await familyMemberRepo.TableNoTracking
               .Include(x => x.SpecialDiseases)
               .SingleAsync(x => x.Id == dto.FamilyMemberId);

            if (familyMember.SpecialDiseases.Any(x => x.FamilyMemberSpecialDiseaseSubjectId == dto.FamilyMemberSpecialDiseaseSubjectId)) {
                throw new Exception("این نیاز قبلا ثبت شده بود.");
            }

            var item = dto.Adapt<FamilyMemberSpecialDisease>();
            item.Order = familyMember.SpecialDiseases.Count + 1;
            item.FamilyId = familyMember.FamilyId;
            await familyMemberSpecialDiseaseRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDisease> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDisease,
                Root2Id = familyMember.FamilyId,
                Root1Id = familyMember.Id,
                EntityId = item.Id,
                ObjA = item,
            });

            return item.Id;
        }
    }
}
