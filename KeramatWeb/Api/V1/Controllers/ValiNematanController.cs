using Entities.ValiNematan;
using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using Services.ValiNematan;
using Services.ValiNematan.Models;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class ValiNematanController : BaseApi {
        private readonly IGetFamiliesListService getFamiliesListService;
        private readonly IInsertFamilyService insertFamilyService;
        private readonly IGetFamilyLevelsListService getFamilyLevelsListService;
        private readonly IGetConnectorsListService getConnectorsListService;

        public ValiNematanController(
            IGetFamiliesListService getFamiliesListService,
            IInsertFamilyService insertFamilyService,
            IGetFamilyLevelsListService getFamilyLevelsListService,
            IGetConnectorsListService getConnectorsListService
            ) {
            this.getFamiliesListService = getFamiliesListService;
            this.insertFamilyService = insertFamilyService;
            this.getFamilyLevelsListService = getFamilyLevelsListService;
            this.getConnectorsListService = getConnectorsListService;
        }

        [HttpGet]
        public async Task<WithPagination<GetFamiliesListItemDto>> List([FromQuery] GetFamiliesListQuery query) {
            return await getFamiliesListService.Search(query);
        }

        [HttpPost]
        public async Task<int> Add([FromBody] InsertFamilyDto dto) {
            return await insertFamilyService.Exe(dto);
        }

        [HttpGet]
        public async Task<List<FamilyLevel>> FamilyLevels() {
            return await getFamilyLevelsListService.Exe();
        }

        [HttpGet]
        public async Task<List<GetConnectorsListItemDto>> Connectors() {
            return await getConnectorsListService.Exe();
        }
    }
}
