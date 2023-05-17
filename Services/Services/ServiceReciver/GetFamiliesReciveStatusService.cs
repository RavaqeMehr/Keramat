using Common;
using Data;
using Entities.Services;
using Entities.ValiNematan;
using Microsoft.EntityFrameworkCore;
using Services.Services.Models;

namespace Services.Services {
    public interface IGetFamiliesReciveStatusService : IScopedDependency {
        Task<List<GetAllNotRecivedFamiliesItemDto>> Exe(int id);
    }

    public class GetFamiliesReciveStatusService : IGetFamiliesReciveStatusService {
        private readonly IRepository<ServiceReciver> serviceReciverRepo;
        private readonly IRepository<Family> familyRepo;

        public GetFamiliesReciveStatusService(
            IRepository<ServiceReciver> serviceReciverRepo,
            IRepository<Family> familyRepo
            ) {
            this.serviceReciverRepo = serviceReciverRepo;
            this.familyRepo = familyRepo;
        }

        public async Task<List<GetAllNotRecivedFamiliesItemDto>> Exe(int id) {
            var recived = serviceReciverRepo.TableNoTracking
                .Include(x => x.Family)
                .Where(x => x.ServiceProvidedId == id)
                .Select(x => x.Family);

            var all = await familyRepo.TableNoTracking
                .Include(x => x.Members)
                .Where(x => !x.Finished)
                .Select(x => new GetAllNotRecivedFamiliesItemDto {
                    Id = x.Id,
                    Title = x.Title,
                    MembersCount = x.Members.Count,
                    Serviced = recived.Any(y => y.Id == x.Id)
                })
                .OrderBy(x => x.Title)
                .ToListAsync();

            return all;
        }
    }
}
