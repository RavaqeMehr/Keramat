using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.AppUsingLogs;
using Services.AppUsingLogs.Models;
using Services.Common;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class ManageController : BaseApi {
        private readonly IGetAppSessionsListService getAppSessionsListService;
        private readonly IGetChangesLogService getChangesLogService;

        public ManageController(
            IGetAppSessionsListService getAppSessionsListService,
            IGetChangesLogService getChangesLogService
            ) {
            this.getAppSessionsListService = getAppSessionsListService;
            this.getChangesLogService = getChangesLogService;
        }

        [HttpGet]
        public async Task<WithPagination<AppSessionDto>> Sessions([FromQuery] int page) {
            return await getAppSessionsListService.Exe(page);
        }

        [HttpGet]
        public async Task<WithPagination<EntityChangesDto>> ChangesLog([FromQuery] GetChangesLogQuery query) {
            return await getChangesLogService.Exe(query);
        }
    }
}
