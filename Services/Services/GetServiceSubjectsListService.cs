using Common;
using Data;
using Entities.Services;
using Microsoft.EntityFrameworkCore;

namespace Services.Services {
    public interface IGetServiceSubjectsListService : IScopedDependency {
        Task<List<ServiceSubject>> Exe();
    }

    public class GetServiceSubjectsListService : IGetServiceSubjectsListService {
        private readonly IRepository<ServiceSubject> serviceSubjectRepo;

        public GetServiceSubjectsListService(
            IRepository<ServiceSubject> serviceSubjectRepo
            ) {
            this.serviceSubjectRepo = serviceSubjectRepo;
        }

        public async Task<List<ServiceSubject>> Exe() {
            return await serviceSubjectRepo.TableNoTracking
                .OrderBy(x => x.Title)
                .ToListAsync();
        }
    }
}
