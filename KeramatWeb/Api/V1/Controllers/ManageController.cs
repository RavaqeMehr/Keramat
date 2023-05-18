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
        private readonly IGetChangesLogService getChangesLogService;
        private readonly IUpdateSettingsService updateSettingsService;

        public ManageController(
            IGetChangesLogService getChangesLogService,
            IUpdateSettingsService updateSettingsService
            ) {
            this.getChangesLogService = getChangesLogService;
            this.updateSettingsService = updateSettingsService;
        }


        [HttpGet]
        public async Task<WithPagination<EntityChangesDto>> ChangesLog([FromQuery] int page = 1) {
            return await getChangesLogService.Exe(page);
        }

        [HttpPut]
        public async Task<bool> Settings([FromBody] UpdateSettingsDto dto) {
            return await updateSettingsService.Exe(dto);
        }
    }
}
