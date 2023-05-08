using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyMemberByIdService : IScopedDependency {
        Task<GetFamilyMemberDto> Exe(int id);
    }

    public class GetFamilyMemberByIdService : IGetFamilyMemberByIdService {
        private readonly IRepository<FamilyMember> familyMemberRepo;

        public GetFamilyMemberByIdService(
            IRepository<FamilyMember> familyMemberRepo
            ) {
            this.familyMemberRepo = familyMemberRepo;
        }

        public async Task<GetFamilyMemberDto> Exe(int id) {
            var item = await familyMemberRepo.TableNoTracking
                .FirstAsync(x => x.Id == id);

            var dto = item.Adapt<GetFamilyMemberDto>();

            if (item.ImpreciseBirthDate.isValueLess()) {
                dto.BirthDateStr = item.BirthDate?.ToPersianDateString() ?? null;
                dto.IsBirthDateImprecise = false;
                dto.Age = item.BirthDate?.GetAge();
            }
            else {
                dto.BirthDateStr = item.ImpreciseBirthDate;
                dto.IsBirthDateImprecise = true;
                dto.Age = item.ImpreciseBirthDate.GetAgeFromShamsiDateStringOrShamsiYearString();
            }

            if (item.ImpreciseDeathDate.isValueLess()) {
                dto.DeathDateStr = item.DeathDate?.ToPersianDateString() ?? null;
                dto.IsDeathDateImprecise = false;
            }
            else {
                dto.DeathDateStr = item.ImpreciseDeathDate;
                dto.IsBirthDateImprecise = true;
            }

            return dto;
        }
    }
}
