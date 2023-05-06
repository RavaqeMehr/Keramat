using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;

namespace Services.ValiNematan {
    public interface IUpdateFamilyMemberSpecialDiseaseSubjectService : IScopedDependency {
        Task<bool> Exe(FamilyMemberSpecialDiseaseSubject dto);
    }

    public class UpdateFamilyMemberSpecialDiseaseSubjectService : IUpdateFamilyMemberSpecialDiseaseSubjectService {
        private readonly IRepository<FamilyMemberSpecialDiseaseSubject> familySpecialDiseaseSubjectRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyMemberSpecialDiseaseSubjectService(
            IRepository<FamilyMemberSpecialDiseaseSubject> familySpecialDiseaseSubjectRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familySpecialDiseaseSubjectRepo = familySpecialDiseaseSubjectRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(FamilyMemberSpecialDiseaseSubject dto) {
            var item = await familySpecialDiseaseSubjectRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();

            item.Title = dto.Title;
            item.Description = dto.Description;

            await familySpecialDiseaseSubjectRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMemberSpecialDiseaseSubject> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMemberSpecialDiseaseSubject,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });

            return true;
        }
    }
}
