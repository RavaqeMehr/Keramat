using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.Dashboard;
using Services.Dashboard.Models;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class HomeController : BaseApi {
        private readonly IGetAppInfoService getAppInfoService;
        private readonly ICheckUpdateService checkUpdateService;

        public HomeController(
            IGetAppInfoService getAppInfoService,
            ICheckUpdateService checkUpdateService
            ) {
            this.getAppInfoService = getAppInfoService;
            this.checkUpdateService = checkUpdateService;
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
            Environment.Exit(Index());
        }

        [HttpGet]
        public async Task<CheckUpdateDto> CheckUpdate() {
            return await checkUpdateService.Exe();
        }
    }
}
