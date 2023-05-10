using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyLevelService : IScopedDependency {
        Task<int> Exe(InsertFamilyLevelDto dto);
    }

    public class InsertFamilyLevelService : IInsertFamilyLevelService {
        private readonly IRepository<FamilyLevel> familyLevelRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyLevelService(
            IRepository<FamilyLevel> familyLevelRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyLevelRepo = familyLevelRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyLevelDto dto) {
            var item = dto.Adapt<FamilyLevel>();
            await familyLevelRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyLevel> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyLevel,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
