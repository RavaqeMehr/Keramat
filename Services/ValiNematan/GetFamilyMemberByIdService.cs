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
                dto.BirthDate = item.BirthDate?.ToPersianDateString() ?? null;
                dto.IsBirthDateImprecise = item.BirthDate.HasValue ? false : null;
                dto.Age = item.BirthDate?.GetAge();
            }
            else {
                dto.BirthDate = item.ImpreciseBirthDate;
                dto.IsBirthDateImprecise = true;
                dto.Age = item.ImpreciseBirthDate.GetAgeFromShamsiDateStringOrShamsiYearString();
            }

            if (item.ImpreciseDeathDate.isValueLess()) {
                dto.DeathDate = item.DeathDate?.ToPersianDateString() ?? null;
                dto.IsDeathDateImprecise = item.DeathDate.HasValue ? false : null;
            }
            else {
                dto.DeathDate = item.ImpreciseDeathDate;
                dto.IsBirthDateImprecise = true;
            }

            return dto;
        }
    }
}
