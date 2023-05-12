using Common;
using Common.Utilities;
using Data;
using Entities.Kheyrat;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Common;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IGetKheyrsListService : IScopedDependency {
        Task<WithPagination<GetKheyrsListItemDto>> Search(int page);
    }

    public class GetKheyrsListService : IGetKheyrsListService {
        private readonly IRepository<Kheyr> kheyrRepo;

        public GetKheyrsListService(
            IRepository<Kheyr> kheyrRepo
            ) {
            this.kheyrRepo = kheyrRepo;
        }

        public async Task<WithPagination<GetKheyrsListItemDto>> Search(int page) {
            IQueryable<Kheyr> listAll = kheyrRepo.TableNoTracking;

            var perPage = 10;

            var output = new WithPagination<GetKheyrsListItemDto>();
            await output.Fill(listAll, page, perPage);
            var items = await listAll
                .OrderByDescending(x => x.Date)
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            output.Items = items.Select(x => {
                var dto = x.Adapt<GetKheyrsListItemDto>();
                dto.DateStr = x.Date.ToPersianDateString();
                return dto;
            }).ToList();

            return output;
        }
    }
}
