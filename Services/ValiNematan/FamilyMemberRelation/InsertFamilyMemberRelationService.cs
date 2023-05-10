using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyMemberRelationService : IScopedDependency {
        Task<int> Exe(InsertFamilyMemberRelationDto dto);
    }

    public class InsertFamilyMemberRelationService : IInsertFamilyMemberRelationService {
        private readonly IRepository<FamilyMemberRelation> familyRelationRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyMemberRelationService(
            IRepository<FamilyMemberRelation> familyRelationRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyRelationRepo = familyRelationRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyMemberRelationDto dto) {
            var item = dto.Adapt<FamilyMemberRelation>();
            await familyRelationRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberRelation> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberRelation,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
