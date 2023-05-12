using Common;
using Data;
using Entities.Kheyrat;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Kheyrat.Models;

namespace Services.Kheyrat {
    public interface IGetNikooKarByIdService : IScopedDependency {
        Task<NikooKarDto> Exe(int id);
    }

    public class GetNikooKarByIdService : IGetNikooKarByIdService {
        private readonly IRepository<NikooKar> nikooKarRepo;

        public GetNikooKarByIdService(
            IRepository<NikooKar> nikooKarRepo
            ) {
            this.nikooKarRepo = nikooKarRepo;
        }

        public async Task<NikooKarDto> Exe(int id) {
            var item = await nikooKarRepo.TableNoTracking
                .FirstAsync(x => x.Id == id);

            return item.Adapt<NikooKarDto>();
        }
    }
}
