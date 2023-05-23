using Common;
using Services.Dashboard.Models;

namespace Services.Dashboard {
    public interface ICheckUpdateService : IScopedDependency {
        Task<CheckUpdateDto> Exe();
    }

    public class CheckUpdateService : ICheckUpdateService {
        private readonly IGetAppInfoService getAppInfoService;
        private readonly GithubApiClient.GithubApiClient githubApiClient;

        public CheckUpdateService(
            IGetAppInfoService getAppInfoService,
            GithubApiClient.GithubApiClient githubApiClient
            ) {
            this.getAppInfoService = getAppInfoService;
            this.githubApiClient = githubApiClient;
        }

        public async Task<CheckUpdateDto> Exe() {
            var appInfo = getAppInfoService.Exe();
            var releases = await githubApiClient.GetReleases();
            var latest = releases?.FirstOrDefault(x => !x.draft && !x.prerelease);

            var latestUrl = "https://github.com/RavaqeMehr/Keramat/releases/latest";

            if (latest is null) {
                return new CheckUpdateDto {
                    CurrentVersion = appInfo.AppVersion,
                    LatestVersion = appInfo.AppVersion,
                    NeedUpdate = false,
                    ReleaseUrl = latestUrl,
                    LatestVersionPublishDate = DateTime.Now
                };
            }
            else {
                return new CheckUpdateDto {
                    CurrentVersion = appInfo.AppVersion,
                    LatestVersion = latest.tag_name.Replace("v", ""),
                    LatestVersionPublishDate = latest.published_at,
                    ReleaseUrl = latestUrl,
                    NeedUpdate = !latest.tag_name.EndsWith(appInfo.AppVersion)
                };
            }
        }
    }
}
