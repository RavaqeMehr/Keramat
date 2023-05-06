using Common;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyMemberRelationUsesListService : IScopedDependency {
        Task<WithPagination<GetUsesListFamilyMemberItemDto>> Exe(GetUsesListQuery query);
    }

    public class GetFamilyMemberRelationUsesListService : IGetFamilyMemberRelationUsesListService {
        private readonly IRepository<FamilyMember> familyMemberRepo;

        public GetFamilyMemberRelationUsesListService(
            IRepository<FamilyMember> familyMemberRepo
            ) {
            this.familyMemberRepo = familyMemberRepo;
        }

        public async Task<WithPagination<GetUsesListFamilyMemberItemDto>> Exe(GetUsesListQuery query) {
            var p = query.Page ?? 1;

            IQueryable<FamilyMember> listAll = familyMemberRepo.TableNoTracking
                .Include(x => x.Family)
                .Where(x => x.FamilyMemberRelationId == query.Id);

            var perPage = 10;

            var output = new WithPagination<GetUsesListFamilyMemberItemDto>();
            await output.Fill(listAll, p, perPage);
            output.Items = await listAll
                .OrderBy(x => x.FamilyId).ThenByDescending(x => x.Name)
                .Skip((p - 1) * perPage)
                .Take(perPage)
                .Select(x => new GetUsesListFamilyMemberItemDto {
                    Id = x.Id,
                    Name = x.Name,
                    FamilyId = x.FamilyId,
                    FamilyTitle = x.Family.Title
                })
                .ToListAsync();

            return output;
        }
    }
}
