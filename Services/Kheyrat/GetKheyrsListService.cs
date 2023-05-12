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
        Task<WithPagination<GetKheyrsListItemDto>> Exe(GetKheyrsListQuery query);
    }

    public class GetKheyrsListService : IGetKheyrsListService {
        private readonly IRepository<Kheyr> kheyrRepo;

        public GetKheyrsListService(
            IRepository<Kheyr> kheyrRepo
            ) {
            this.kheyrRepo = kheyrRepo;
        }

        public async Task<WithPagination<GetKheyrsListItemDto>> Exe(GetKheyrsListQuery query) {
            IQueryable<Kheyr> listAll = kheyrRepo.TableNoTracking;

            if (query.NikooKarId is not null) {
                listAll = listAll.Where(x => x.NikooKarId == query.NikooKarId);
            }

            var perPage = 10;

            var output = new WithPagination<GetKheyrsListItemDto>();
            await output.Fill(listAll, query.Page, perPage);
            var items = await listAll
                .OrderByDescending(x => x.Date)
                .Skip((query.Page - 1) * perPage)
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
