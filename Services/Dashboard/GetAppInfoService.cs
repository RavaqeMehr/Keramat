using Common;
using Entities.AppSettings;
using Services.AppLayer;
using Services.AppUsingLogs;
using Services.Dashboard.Models;

namespace Services.Dashboard {
    public interface IGetAppInfoService : IScopedDependency {
        GetAppInfoDto Exe();
    }

    public class GetAppInfoService : IGetAppInfoService {
        private readonly IAppSettingsService appSettingsService;
        private readonly IAppSessionService appSessionService;

        public GetAppInfoService(
            IAppSettingsService appSettingsService,
            IAppSessionService appSessionService
            ) {
            this.appSettingsService = appSettingsService;
            this.appSessionService = appSessionService;
        }

        public GetAppInfoDto Exe() {
            return new GetAppInfoDto {
                SesseionId = appSessionService.ThisSession.Id,
                CharityName = appSettingsService.Get(AppSettingsKeys.Charity_Name) ?? "",
                CharitySlogan = appSettingsService.Get(AppSettingsKeys.Charity_Slogan) ?? ""
            };
        }
    }
}
