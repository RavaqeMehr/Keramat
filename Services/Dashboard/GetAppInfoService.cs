using Common;
using Entities.AppSettings;
using Services.AppLayer;
using Services.Dashboard.Models;

namespace Services.Dashboard {
    public interface IGetAppInfoService : IScopedDependency {
        GetAppInfoDto Exe();
    }

    public class GetAppInfoService : IGetAppInfoService {
        private readonly IAppSettingsService appSettingsService;

        public GetAppInfoService(
            IAppSettingsService appSettingsService
            ) {
            this.appSettingsService = appSettingsService;
        }

        public GetAppInfoDto Exe() {
            return new GetAppInfoDto {
                CharityName = appSettingsService.Get(AppSettingsKeys.Charity_Name) ?? "",
                CharitySlogan = appSettingsService.Get(AppSettingsKeys.Charity_Slogan) ?? "",
                AppVersion = appSettingsService.Get(AppSettingsKeys.App_Version) ?? "1.0"
            };
        }
    }
}
