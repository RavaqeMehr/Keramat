using Common;
using Data;
using Entities.AppUsingLogs;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.AppUsingLogs.Models;
using Services.Common;

namespace Services.AppUsingLogs {
    public interface IGetChangesLogService : IScopedDependency {
        Task<WithPagination<EntityChangesDto>> Exe(GetChangesLogQuery query);
    }

    public class GetChangesLogService : IGetChangesLogService {
        private readonly IRepository<EntityChanges> entityChangesRepo;

        public GetChangesLogService(
            IRepository<EntityChanges> entityChangesRepo
            ) {
            this.entityChangesRepo = entityChangesRepo;
        }

        public async Task<WithPagination<EntityChangesDto>> Exe(GetChangesLogQuery query) {
            IQueryable<EntityChanges> listAll = entityChangesRepo.TableNoTracking
               .OrderByDescending(x => x.Date);
            if (query.AppSessionId is not null) {
                listAll = listAll.Where(x => x.AppSessionId == query.AppSessionId);
            }

            var perPage = 10;

            var output = new WithPagination<EntityChangesDto>();
            await output.Fill(listAll, query.Page, perPage);
            var items = await listAll
                .Skip((query.Page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            output.Items = items
                .Select(x => {
                    var dto = x.Adapt<EntityChangesDto>();
                    dto.ChangedProps = x.Changes?.Split(new string[] { "\r\n", "\n\r", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                    dto.ChangedPropsCount = dto.ChangedProps.Length;
                    return dto;
                })
                .ToList();

            return output;
        }
    }
}
