using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.AppLayer;
using Services.AppLayer.Models;
using Services.AppUsingLogs;
using Services.AppUsingLogs.Models;
using Services.Common;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class ManageController : BaseApi {
        private readonly IGetAppSessionsListService getAppSessionsListService;
        private readonly IGetChangesLogService getChangesLogService;
        private readonly IUpdateSettingsService updateSettingsService;

        public ManageController(
            IGetAppSessionsListService getAppSessionsListService,
            IGetChangesLogService getChangesLogService,
            IUpdateSettingsService updateSettingsService
            ) {
            this.getAppSessionsListService = getAppSessionsListService;
            this.getChangesLogService = getChangesLogService;
            this.updateSettingsService = updateSettingsService;
        }

        [HttpGet]
        public async Task<WithPagination<AppSessionDto>> Sessions([FromQuery] int page) {
            return await getAppSessionsListService.Exe(page);
        }

        [HttpGet]
        public async Task<WithPagination<EntityChangesDto>> ChangesLog([FromQuery] GetChangesLogQuery query) {
            return await getChangesLogService.Exe(query);
        }

        [HttpPut]
        public async Task<bool> Settings([FromBody] UpdateSettingsDto dto) {
            return await updateSettingsService.Exe(dto);
        }
    }
}
