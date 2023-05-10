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

            if (dto.BirthDateStr.HasValue()) {
                if (dto.IsBirthDateImprecise) {
                    item.BirthDate = null;
                    item.ImpreciseBirthDate = dto.BirthDateStr;
                }
                else {
                    var date = dto.BirthDateStr?.GetDateTimeFromShamsiDateString();
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
            else {
                item.ImpreciseBirthDate = "";
            }

            if ((dto.LiveStatus == Enums.LiveStatus.Dead || dto.LiveStatus == Enums.LiveStatus.Martyr) && dto.DeathDateStr.HasValue()) {
                if (dto.IsDeathDateImprecise) {
                    item.DeathDate = null;
                    item.ImpreciseDeathDate = dto.DeathDateStr;
                }
                else {
                    var date = dto.DeathDateStr?.GetDateTimeFromShamsiDateString();
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
                    item.ImpreciseDeathDate = "";
                }
            }
            else {
                item.DeathDate = null;
                item.DeathDateY = null;
                item.DeathDateM = null;
                item.DeathDateD = null;
                item.ImpreciseDeathDate = "";
            }

            await familyMemberRepo.AddAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMember> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Add,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMember,
                Root1Id = item.FamilyId,
                EntityId = item.Id,
                ObjA = item
            });

            return item.Id;
        }
    }
}
