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
        private readonly IGetFamilyByIdService getFamilyByIdService;
        private readonly IUpdateFamilyService updateFamilyService;
        private readonly IGetFamilyLevelsListService getFamilyLevelsListService;
        private readonly IInsertFamilyLevelService insertFamilyLevelService;
        private readonly IUpdateFamilyLevelService updateFamilyLevelService;
        private readonly IGetFamilyLevelUsesListService getFamilyLevelUsesListService;
        private readonly IRemoveFamilyLevelService removeFamilyLevelService;
        private readonly IGetConnectorsListService getConnectorsListService;
        private readonly IInsertConnectorService insertConnectorService;
        private readonly IUpdateConnectorService updateConnectorService;
        private readonly IGetConnectorUsesListService getConnectorUsesListService;
        private readonly IRemoveConnectorService removeConnectorService;
        private readonly IGetFamilyNeedSubjectsListService getFamilyNeedSubjectsListService;
        private readonly IInsertFamilyNeedSubjectService insertFamilyNeedSubjectService;
        private readonly IUpdateFamilyNeedSubjectService updateFamilyNeedSubjectService;
        private readonly IGetFamilyNeedSubjectUsesListService getFamilyNeedSubjectUsesListService;

        public ValiNematanController(
            IGetFamiliesListService getFamiliesListService,
            IInsertFamilyService insertFamilyService,
            IGetFamilyByIdService getFamilyByIdService,
            IUpdateFamilyService updateFamilyService,
            IGetFamilyLevelsListService getFamilyLevelsListService,
            IInsertFamilyLevelService insertFamilyLevelService,
            IUpdateFamilyLevelService updateFamilyLevelService,
            IGetFamilyLevelUsesListService getFamilyLevelUsesListService,
            IRemoveFamilyLevelService removeFamilyLevelService,
            IGetConnectorsListService getConnectorsListService,
            IInsertConnectorService insertConnectorService,
            IUpdateConnectorService updateConnectorService,
            IGetConnectorUsesListService getConnectorUsesListService,
            IRemoveConnectorService removeConnectorService,
            IGetFamilyNeedSubjectsListService getFamilyNeedSubjectsListService,
            IInsertFamilyNeedSubjectService insertFamilyNeedSubjectService,
            IUpdateFamilyNeedSubjectService updateFamilyNeedSubjectService,
            IGetFamilyNeedSubjectUsesListService getFamilyNeedSubjectUsesListService
            ) {
            this.getFamiliesListService = getFamiliesListService;
            this.insertFamilyService = insertFamilyService;
            this.getFamilyByIdService = getFamilyByIdService;
            this.updateFamilyService = updateFamilyService;
            this.getFamilyLevelsListService = getFamilyLevelsListService;
            this.insertFamilyLevelService = insertFamilyLevelService;
            this.updateFamilyLevelService = updateFamilyLevelService;
            this.getFamilyLevelUsesListService = getFamilyLevelUsesListService;
            this.removeFamilyLevelService = removeFamilyLevelService;
            this.getConnectorsListService = getConnectorsListService;
            this.insertConnectorService = insertConnectorService;
            this.updateConnectorService = updateConnectorService;
            this.getConnectorUsesListService = getConnectorUsesListService;
            this.removeConnectorService = removeConnectorService;
            this.getFamilyNeedSubjectsListService = getFamilyNeedSubjectsListService;
            this.insertFamilyNeedSubjectService = insertFamilyNeedSubjectService;
            this.updateFamilyNeedSubjectService = updateFamilyNeedSubjectService;
            this.getFamilyNeedSubjectUsesListService = getFamilyNeedSubjectUsesListService;
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

        [HttpPost]
        public async Task<int> AddConnector([FromBody] InsertConnectorDto dto) {
            return await insertConnectorService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditConnector([FromBody] UpdateConnectorDto dto) {
            return await updateConnectorService.Exe(dto);
        }

        [HttpGet]
        public async Task<WithPagination<GetConnectorUsesListItemDto>> ConnectorUsesList([FromQuery] GetConnectorUsesListQuery query) {
            return await getConnectorUsesListService.Exe(query);
        }

        [HttpDelete]
        public async Task<bool> RemoveConnector([FromQuery] int id) {
            return await removeConnectorService.Exe(id);
        }

        [HttpGet]
        public async Task<List<FamilyNeedSubject>> FamilyNeedSubjects() {
            return await getFamilyNeedSubjectsListService.Exe();
        }

        [HttpPost]
        public async Task<int> AddFamilyNeedSubject([FromBody] InsertFamilyNeedSubjectDto dto) {
            return await insertFamilyNeedSubjectService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditFamilyNeedSubject([FromBody] FamilyNeedSubject dto) {
            return await updateFamilyNeedSubjectService.Exe(dto);
        }

        [HttpGet]
        public async Task<WithPagination<GetUsesListFamilyItemDto>> FamilyNeedSubjectUsesList([FromQuery] GetUsesListQuery query) {
            return await getFamilyNeedSubjectUsesListService.Exe(query);
        }
    }
}
