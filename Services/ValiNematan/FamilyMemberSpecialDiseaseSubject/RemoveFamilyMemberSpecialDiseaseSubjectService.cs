using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IRemoveFamilyMemberSpecialDiseaseSubjectService : IScopedDependency {
        Task<bool> Exe(int id);
    }

    public class RemoveFamilyMemberSpecialDiseaseSubjectService : IRemoveFamilyMemberSpecialDiseaseSubjectService {
        private readonly IRepository<FamilyMemberSpecialDiseaseSubject> familyMemberSpecialDiseaseSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public RemoveFamilyMemberSpecialDiseaseSubjectService(
            IRepository<FamilyMemberSpecialDiseaseSubject> familyMemberSpecialDiseaseSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberSpecialDiseaseSubjectRepo = familyMemberSpecialDiseaseSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(int id) {
            var item = await familyMemberSpecialDiseaseSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            var item_ = item.Clone();

            await familyMemberSpecialDiseaseSubjectRepo.DeleteAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDiseaseSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Delete,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDiseaseSubject,
                EnitityId = item.Id,
                ObjA = item_,
            });

            return true;
        }
    }
}
