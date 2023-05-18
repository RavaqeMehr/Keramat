using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.Dashboard;
using Services.Dashboard.Models;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class HomeController : BaseApi {
        private readonly IGetAppInfoService getAppInfoService;

        public HomeController(
            IGetAppInfoService getAppInfoService
            ) {
            this.getAppInfoService = getAppInfoService;
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
    }
}
