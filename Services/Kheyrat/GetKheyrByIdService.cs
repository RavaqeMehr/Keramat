using Common;
using Data;
using Entities.Kheyrat;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IGetKheyrByIdService : IScopedDependency {
        Task<KheyrDto> Exe(int id);
    }

    public class GetKheyrByIdService : IGetKheyrByIdService {
        private readonly IRepository<Kheyr> kheyrRepo;

        public GetKheyrByIdService(
            IRepository<Kheyr> kheyrRepo
            ) {
            this.kheyrRepo = kheyrRepo;
        }

        public async Task<KheyrDto> Exe(int id) {
            var item = await kheyrRepo.TableNoTracking
                .FirstAsync(x => x.Id == id);

            return item.Adapt<KheyrDto>();
        }
    }
}
