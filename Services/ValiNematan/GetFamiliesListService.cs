using Common;
using Common.Utilities;
using Data;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.ComonModels;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamiliesListService : ITransientDependency {
        Task<WithPagination<GetFamiliesListItemDto>> Search(string search, int page = 1);
        //Task<List<GetFamiliesListItemDto>> SearchPro(string search, int page=1);
    }

    public class GetFamiliesListService : IGetFamiliesListService {
        private readonly IRepository<Family> familyRepo;

        public GetFamiliesListService(
            IRepository<Family> familyRepo
            ) {
            this.familyRepo = familyRepo;
        }

        public async Task<WithPagination<GetFamiliesListItemDto>> Search(string? search, int page = 1) {
            var s = search.GetStringValue();

            IQueryable<Family> listAll = familyRepo.TableNoTracking
                .Include(x => x.Members);

            if (s.Length > 0) {
                listAll = listAll.Where(x =>
                x.Title.Contains(s) ||
                x.Address.Contains(s) ||
                x.Description.Contains(s) ||
                x.ContactPersonName.Contains(s) ||
                x.ContactPersonDescription.Contains(s) ||
                x.ContactPersonPhone.Contains(s) ||

                x.Members.Any(m =>
                    m.Name.Contains(s) ||
                    m.NationalCode.Contains(s) ||
                    m.Phone.Contains(s) ||
                    m.Description.Contains(s) ||
                    m.Job.Contains(s) ||
                    m.JobAddress.Contains(s) ||
                    m.JobDescription.Contains(s) ||
                    m.JobPhone.Contains(s)
                    )
                );
            }

            var perPage = 100;

            var output = new WithPagination<GetFamiliesListItemDto>();
            await output.Fill(listAll, page, perPage);
            output.Items = await listAll
                .OrderBy(x => x.Title).ThenByDescending(x => x.AddDate)
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(x => new GetFamiliesListItemDto {
                    Id = x.Id,
                    Title = x.Title,
                    Level = x.Level,
                    MembersCount = x.Members.Count(m => m.LiveStatus != Enums.LiveStatus.Dead || m.LiveStatus != Enums.LiveStatus.Martyr)
                })
                .ToListAsync();

            return output;
        }
    }
}
