using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.AppUsingLogs;
using Services.Dashboard;
using Services.Dashboard.Models;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class HomeController : BaseApi {
        private readonly IGetAppInfoService getAppInfoService;
        private readonly IAppSessionService appSessionService;

        public HomeController(
            IGetAppInfoService getAppInfoService,
            IAppSessionService appSessionService
            ) {
            this.getAppInfoService = getAppInfoService;
            this.appSessionService = appSessionService;
        }

        [HttpGet]
        public int Index() {
            return 786;
        }

        [HttpGet]
        public GetAppInfoDto AppInfo() {
            return getAppInfoService.Exe();
        }

        [HttpDelete]
        public void Exit() {
            appSessionService.Stop();
        }
    }
}
