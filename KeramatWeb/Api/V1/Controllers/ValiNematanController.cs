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
        private readonly IGetFamilyByIdService getFamilyByIdService;
        private readonly IUpdateFamilyService updateFamilyService;
        private readonly IInsertFamilyLevelService insertFamilyLevelService;
        private readonly IUpdateFamilyLevelService updateFamilyLevelService;
        private readonly IGetFamilyLevelUsesListService getFamilyLevelUsesListService;
        private readonly IRemoveFamilyLevelService removeFamilyLevelService;

        public ValiNematanController(
            IGetFamiliesListService getFamiliesListService,
            IInsertFamilyService insertFamilyService,
            IGetFamilyLevelsListService getFamilyLevelsListService,
            IGetConnectorsListService getConnectorsListService,
            IGetFamilyByIdService getFamilyByIdService,
            IUpdateFamilyService updateFamilyService,
            IInsertFamilyLevelService insertFamilyLevelService,
            IUpdateFamilyLevelService updateFamilyLevelService,
            IGetFamilyLevelUsesListService getFamilyLevelUsesListService,
            IRemoveFamilyLevelService removeFamilyLevelService
            ) {
            this.getFamiliesListService = getFamiliesListService;
            this.insertFamilyService = insertFamilyService;
            this.getFamilyLevelsListService = getFamilyLevelsListService;
            this.getConnectorsListService = getConnectorsListService;
            this.getFamilyByIdService = getFamilyByIdService;
            this.updateFamilyService = updateFamilyService;
            this.insertFamilyLevelService = insertFamilyLevelService;
            this.updateFamilyLevelService = updateFamilyLevelService;
            this.getFamilyLevelUsesListService = getFamilyLevelUsesListService;
            this.removeFamilyLevelService = removeFamilyLevelService;
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
        public async Task<GetFamilyByIdDto> Single([FromQuery] int id) {
            return await getFamilyByIdService.Exe(id);
        }

        [HttpPut]
        public async Task<bool> Edit([FromBody] UpdateFamilyDto dto) {
            return await updateFamilyService.Exe(dto);
        }

        [HttpGet]
        public async Task<List<FamilyLevel>> FamilyLevels() {
            return await getFamilyLevelsListService.Exe();
        }

        [HttpPost]
        public async Task<int> AddFamilyLevel([FromBody] InsertFamilyLevelDto dto) {
            return await insertFamilyLevelService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditFamilyLevel([FromBody] UpdateFamilyLevelDto dto) {
            return await updateFamilyLevelService.Exe(dto);
        }

        [HttpGet]
        public async Task<WithPagination<GetFamilyLevelUsesListItemDto>> FamilyLevelUsesList([FromQuery] GetFamilyLevelUsesListQuery query) {
            return await getFamilyLevelUsesListService.Exe(query);
        }

        [HttpDelete]
        public async Task<bool> RemoveFamilyLevel([FromQuery] int id) {
            return await removeFamilyLevelService.Exe(id);
        }

        [HttpGet]
        public async Task<List<GetConnectorsListItemDto>> Connectors() {
            return await getConnectorsListService.Exe();
        }

    }
}
