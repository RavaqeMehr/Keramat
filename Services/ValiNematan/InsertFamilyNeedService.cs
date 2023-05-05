using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyNeedService : IScopedDependency {
        Task<int> Exe(InsertFamilyNeedDto dto);
    }

    public class InsertFamilyNeedService : IInsertFamilyNeedService {
        private readonly IRepository<Family> familyRepo;
        private readonly IRepository<FamilyNeed> familyNeedRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyNeedService(
            IRepository<Family> familyRepo,
            IRepository<FamilyNeed> familyNeedRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyRepo = familyRepo;
            this.familyNeedRepo = familyNeedRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyNeedDto dto) {
            var family = await familyRepo.TableNoTracking
               .Include(x => x.Needs)
               .SingleAsync(x => x.Id == dto.FamilyId);

            if (family.Needs.Any(x => x.FamilyNeedSubjectId == dto.FamilyNeedSubjectId)) {
                throw new Exception("این نیاز قبلا ثبت شده بود.");
            }

            var item = dto.Adapt<FamilyNeed>();
            item.Order = family.Needs.Count + 1;
            await familyNeedRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyNeed> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyNeed,
                Root1Id = family.Id,
                EnitityId = item.Id,
                ObjA = item,
            });

            return item.Id;
        }
    }
}
