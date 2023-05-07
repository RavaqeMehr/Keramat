using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Mapster;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IInsertFamilyMemberService : IScopedDependency {
        Task<int> Exe(InsertFamilyMemberDto dto);
    }

    public class InsertFamilyMemberService : IInsertFamilyMemberService {
        private readonly IRepository<FamilyMember> familyMemberRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public InsertFamilyMemberService(
            IRepository<FamilyMember> familyMemberRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberRepo = familyMemberRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<int> Exe(InsertFamilyMemberDto dto) {
            var item = dto.Adapt<FamilyMember>();

            if (dto.BirthDate.HasValue()) {
                if (dto.IsBirthDateImprecise) {
                    item.BirthDate = null;
                    item.ImpreciseBirthDate = dto.BirthDate;
                }
                else {
                    var date = dto.BirthDate?.GetDateTimeFromShamsiDateString();
                    if (date is null) {
                        throw new Exception("تاریخ تولد درست وارد نشده است!");
                    }
                    else {
                        item.BirthDate = date;

                        var fa = date.Value.ToPersianDateTime();
                        item.BirthDateY = fa.Year;
                        item.BirthDateM = fa.Month;
                        item.BirthDateD = fa.Day;
                    }
                }
            }

            if (dto.DeathDate.HasValue()) {
                if (dto.IsDeathDateImprecise) {
                    item.DeathDate = null;
                    item.ImpreciseDeathDate = dto.DeathDate;
                }
                else {
                    var date = dto.DeathDate?.GetDateTimeFromShamsiDateString();
                    if (date is null) {
                        throw new Exception("تاریخ وفات/شهادت درست وارد نشده است!");
                    }
                    else {
                        item.DeathDate = date;

                        var fa = date.Value.ToPersianDateTime();
                        item.DeathDateY = fa.Year;
                        item.DeathDateM = fa.Month;
                        item.DeathDateD = fa.Day;
                    }
                }
            }

            await familyMemberRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMember> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMember,
                Root1Id = item.FamilyId,
                EnitityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
