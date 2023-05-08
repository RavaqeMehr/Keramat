using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IUpdateFamilyMemberService : IScopedDependency {
        Task<bool> Exe(UpdateFamilyMemberDto dto);
    }

    public class UpdateFamilyMemberService : IUpdateFamilyMemberService {
        private readonly IRepository<FamilyMember> familyMemberRepo;
        private readonly IAddEntityChangeService addEntityChangeService;

        public UpdateFamilyMemberService(
            IRepository<FamilyMember> familyMemberRepo,
            IAddEntityChangeService addEntityChangeService
            ) {
            this.familyMemberRepo = familyMemberRepo;
            this.addEntityChangeService = addEntityChangeService;
        }

        public async Task<bool> Exe(UpdateFamilyMemberDto dto) {
            var item = await familyMemberRepo.TableNoTracking.FirstAsync(x => x.Id == dto.Id);
            var item_ = item.Clone();


            item.FamilyMemberRelationId = dto.FamilyMemberRelationId;
            item.Gender = dto.Gender;
            item.MaritalStatus = dto.MaritalStatus;
            item.Name = dto.Name;
            item.LastName = dto.LastName;
            item.FathersName = dto.FathersName;
            item.Phone = dto.Phone;
            item.NationalCode = dto.NationalCode;
            item.Description = dto.Description;
            item.Job = dto.Job;
            item.JobDescription = dto.JobDescription;
            item.JobAddress = dto.JobAddress;
            item.JobPhone = dto.JobPhone;
            item.LiveStatus = dto.LiveStatus;

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
            else {
                item.BirthDate = null;
                item.BirthDateY = null;
                item.BirthDateM = null;
                item.BirthDateD = null;
                item.ImpreciseBirthDate = "";
            }

            if ((dto.LiveStatus == Enums.LiveStatus.Dead || dto.LiveStatus == Enums.LiveStatus.Martyr) && dto.DeathDate.HasValue()) {
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
            else {
                item.DeathDate = null;
                item.DeathDateY = null;
                item.DeathDateM = null;
                item.DeathDateD = null;
                item.ImpreciseDeathDate = "";
            }

            await familyMemberRepo.UpdateAsync(item);

            await addEntityChangeService.Exe(new AppUsingLogs.Models.AddEntityChangeInputs<FamilyMember> {
                ChangeType = Entities.AppUsingLogs.ChangeType.Edit,
                EnitityType = Entities.AppUsingLogs.EnitityType.FamilyMember,
                Root1Id = item.FamilyId,
                EnitityId = item.Id,
                ObjA = item_,
                ObjB = item
            });


            return true;
        }
    }
}
