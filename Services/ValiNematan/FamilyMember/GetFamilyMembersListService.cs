using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyMembersListService : IScopedDependency {
        Task<List<GetFamilyMembersItemDto>> Exe(int familyId);
    }

    public class GetFamilyMembersListService : IGetFamilyMembersListService {
        private readonly IRepository<FamilyMember> familyMemberRepo;
        private readonly IRepository<FamilyMemberRelation> familyMemberRelationRepo;

        public GetFamilyMembersListService(
            IRepository<FamilyMember> familyMemberRepo,
            IRepository<FamilyMemberRelation> familyMemberRelationRepo
            ) {
            this.familyMemberRepo = familyMemberRepo;
            this.familyMemberRelationRepo = familyMemberRelationRepo;
        }

        public async Task<List<GetFamilyMembersItemDto>> Exe(int familyId) {
            var items = await familyMemberRepo.TableNoTracking
                .Where(x => x.FamilyId == familyId)
                .ToListAsync();

            var output = new List<GetFamilyMembersItemDto>();

            foreach (var item in items) {
                var dto = item.Adapt<GetFamilyMembersItemDto>();

                if (item.ImpreciseBirthDate.isValueLess()) {
                    dto.Age = item.BirthDate?.GetAge();
                }
                else {
                    dto.Age = item.ImpreciseBirthDate.GetAgeFromShamsiDateStringOrShamsiYearString();
                }

                output.Add(dto);
            }

            var relations = await familyMemberRelationRepo.TableNoTracking
                .OrderBy(x => x.Order)
                .Select(x => x.Id)
                .ToListAsync();

            return output
                .OrderBy(x => relations.IndexOf(x.FamilyMemberRelationId))
                .ToList();
        }
    }
}
