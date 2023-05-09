using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.AppUsingLogs;
using Services.AppUsingLogs.Models;
using Services.Common;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class ManageController : BaseApi {
        private readonly IGetAppSessionsListService getAppSessionsListService;

        public ManageController(
            IGetAppSessionsListService getAppSessionsListService
            ) {
            this.getAppSessionsListService = getAppSessionsListService;
        }

        [HttpGet]
        public async Task<WithPagination<AppSessionDto>> Sessions(int page) {
            return await getAppSessionsListService.Exe(page);
        }
    }
}
