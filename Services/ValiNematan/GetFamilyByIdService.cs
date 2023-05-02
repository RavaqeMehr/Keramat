using Common;
using Data;
using Entities.ValiNematan;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.ValiNematan.Models;

namespace Services.ValiNematan {
    public interface IGetFamilyByIdService : IScopedDependency {
        Task<GetFamilyByIdDto> Exe(int id);
    }

    public class GetFamilyByIdService : IGetFamilyByIdService {
        private readonly IRepository<Family> familyRepo;

        public GetFamilyByIdService(
            IRepository<Family> familyRepo
            ) {
            this.familyRepo = familyRepo;
        }

        public async Task<GetFamilyByIdDto> Exe(int id) {
            var item = await familyRepo.TableNoTracking.FirstAsync(x => x.Id == id);
            return item.Adapt<GetFamilyByIdDto>();
        }
    }
}
