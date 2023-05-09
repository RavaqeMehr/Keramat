using Common;
using Data;
using Entities.AppUsingLogs;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs.Models;
using Services.Common;

namespace Services.AppUsingLogs {
    public interface IGetAppSessionsListService : IScopedDependency {
        Task<WithPagination<AppSessionDto>> Exe(int page = 1);
    }

    public class GetAppSessionsListService : IGetAppSessionsListService {
        private readonly IRepository<AppSession> appSessionRepo;

        public GetAppSessionsListService(
            IRepository<AppSession> appSessionRepo
            ) {
            this.appSessionRepo = appSessionRepo;
        }

        public async Task<WithPagination<AppSessionDto>> Exe(int page = 1) {
            var listAll = appSessionRepo.TableNoTracking
                .Include(x => x.ChangesList)
                .OrderByDescending(x => x.StartDate);

            var perPage = 10;

            var output = new WithPagination<AppSessionDto>();
            await output.Fill(listAll, page, perPage);
            var items = await listAll
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .Select(x => new { item = x, changesCount = x.ChangesList.Count })
                .ToListAsync();

            output.Items = items
                .Select(x => {
                    var dto = x.item.Adapt<AppSessionDto>();
                    dto.ChangesCount = x.changesCount;
                    return dto;
                })
                .ToList();

            return output;
        }
    }
}
