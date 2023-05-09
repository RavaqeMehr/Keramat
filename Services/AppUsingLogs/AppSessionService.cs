using Common;
using Common.Utilities;
using Data;
using Entities.AppUsingLogs;

namespace Services.AppUsingLogs {
    public interface IAppSessionService : ISingletonDependency {
        Task Start();
        Task Stop();
        AppSession ThisSession { get; }
    }

    public class AppSessionService : IAppSessionService {
        private readonly IRepository<AppSession> appSessionRepo;

        public AppSessionService(
            IRepository<AppSession> appSessionRepo
            ) {
            this.appSessionRepo = appSessionRepo;
        }

        public AppSession _ThisSession { get; set; }
        public AppSession ThisSession => _ThisSession;

        public async Task Start() {
            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();

            var item = new AppSession {
                StartDate = now,
                StartDateY = nowFa.Year,
                StartDateM = nowFa.Month,
                StartDateD = nowFa.Day,
            };

            await appSessionRepo.AddAsync(item);
            _ThisSession = item;
        }

        public async Task Stop() {
            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();

            _ThisSession.EndDate = now;
            _ThisSession.EndDateY = nowFa.Year;
            _ThisSession.EndDateM = nowFa.Month;
            _ThisSession.EndDateD = nowFa.Day;
            _ThisSession.DurationSeconds = (now - _ThisSession.StartDate).Seconds;

            await appSessionRepo.UpdateAsync(_ThisSession);

            Environment.Exit(786);
        }
    }
}
