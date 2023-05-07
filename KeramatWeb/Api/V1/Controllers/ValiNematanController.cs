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
        private readonly IRemoveFamilyService removeFamilyService;
        private readonly IGetFamilyNeedsListService getFamilyNeedsListService;
        private readonly IInsertFamilyNeedService insertFamilyNeedService;
        private readonly IUpdateFamilyNeedService updateFamilyNeedService;
        private readonly IRemoveFamilyNeedService removeFamilyNeedService;
        private readonly IReOrderFamilyNeedService reOrderFamilyNeedService;
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
        private readonly IRemoveFamilyNeedSubjectService removeFamilyNeedSubjectService;
        private readonly IGetFamilyMemberNeedSubjectsListService getFamilyMemberNeedSubjectsListService;
        private readonly IInsertFamilyMemberNeedSubjectService insertFamilyMemberNeedSubjectService;
        private readonly IUpdateFamilyMemberNeedSubjectService updateFamilyMemberNeedSubjectService;
        private readonly IGetFamilyMemberNeedSubjectUsesListService getFamilyMemberNeedSubjectUsesListService;
        private readonly IRemoveFamilyMemberNeedSubjectService removeFamilyMemberNeedSubjectService;
        private readonly IGetFamilyMemberSpecialDiseaseSubjectsListService getFamilyMemberSpecialDiseaseSubjectsListService;
        private readonly IInsertFamilyMemberSpecialDiseaseSubjectService insertFamilyMemberSpecialDiseaseSubjectService;
        private readonly IUpdateFamilyMemberSpecialDiseaseSubjectService updateFamilyMemberSpecialDiseaseSubjectService;
        private readonly IGetFamilyMemberSpecialDiseaseSubjectUsesListService getFamilyMemberSpecialDiseaseSubjectUsesListService;
        private readonly IRemoveFamilyMemberSpecialDiseaseSubjectService removeFamilyMemberSpecialDiseaseSubjectService;
        private readonly IGetFamilyMemberRelationsListService getFamilyMemberRelationsListService;
        private readonly IInsertFamilyMemberRelationService insertFamilyMemberRelationService;
        private readonly IUpdateFamilyMemberRelationService updateFamilyMemberRelationService;
        private readonly IGetFamilyMemberRelationUsesListService getFamilyMemberRelationUsesListService;
        private readonly IRemoveFamilyMemberRelationService removeFamilyMemberRelationService;
        private readonly IReOrderFamilyMemberRelationService reOrderFamilyMemberRelationService;
        private readonly IGetFamilyMembersListService getFamilyMembersListService;
        private readonly IGetFamilyMemberByIdService getFamilyMemberByIdService;
        private readonly IInsertFamilyMemberService insertFamilyMemberService;
        private readonly IUpdateFamilyMemberService updateFamilyMemberService;
        private readonly IRemoveFamilyMemberService removeFamilyMemberService;

        public ValiNematanController(
            IGetFamiliesListService getFamiliesListService,
            IInsertFamilyService insertFamilyService,
            IGetFamilyByIdService getFamilyByIdService,
            IUpdateFamilyService updateFamilyService,
            IRemoveFamilyService removeFamilyService,
        ////////////
            IGetFamilyNeedsListService getFamilyNeedsListService,
            IInsertFamilyNeedService insertFamilyNeedService,
            IUpdateFamilyNeedService updateFamilyNeedService,
            IRemoveFamilyNeedService removeFamilyNeedService,
            IReOrderFamilyNeedService reOrderFamilyNeedService,
        ////////////
            IGetFamilyLevelsListService getFamilyLevelsListService,
            IInsertFamilyLevelService insertFamilyLevelService,
            IUpdateFamilyLevelService updateFamilyLevelService,
            IGetFamilyLevelUsesListService getFamilyLevelUsesListService,
            IRemoveFamilyLevelService removeFamilyLevelService,
        ////////////
            IGetConnectorsListService getConnectorsListService,
            IInsertConnectorService insertConnectorService,
            IUpdateConnectorService updateConnectorService,
            IGetConnectorUsesListService getConnectorUsesListService,
            IRemoveConnectorService removeConnectorService,
        ////////////
            IGetFamilyNeedSubjectsListService getFamilyNeedSubjectsListService,
            IInsertFamilyNeedSubjectService insertFamilyNeedSubjectService,
            IUpdateFamilyNeedSubjectService updateFamilyNeedSubjectService,
            IGetFamilyNeedSubjectUsesListService getFamilyNeedSubjectUsesListService,
            IRemoveFamilyNeedSubjectService removeFamilyNeedSubjectService,
        ////////////
            IGetFamilyMemberNeedSubjectsListService getFamilyMemberNeedSubjectsListService,
            IInsertFamilyMemberNeedSubjectService insertFamilyMemberNeedSubjectService,
            IUpdateFamilyMemberNeedSubjectService updateFamilyMemberNeedSubjectService,
            IGetFamilyMemberNeedSubjectUsesListService getFamilyMemberNeedSubjectUsesListService,
            IRemoveFamilyMemberNeedSubjectService removeFamilyMemberNeedSubjectService,
        ////////////
            IGetFamilyMemberSpecialDiseaseSubjectsListService getFamilyMemberSpecialDiseaseSubjectsListService,
            IInsertFamilyMemberSpecialDiseaseSubjectService insertFamilyMemberSpecialDiseaseSubjectService,
            IUpdateFamilyMemberSpecialDiseaseSubjectService updateFamilyMemberSpecialDiseaseSubjectService,
            IGetFamilyMemberSpecialDiseaseSubjectUsesListService getFamilyMemberSpecialDiseaseSubjectUsesListService,
            IRemoveFamilyMemberSpecialDiseaseSubjectService removeFamilyMemberSpecialDiseaseSubjectService,
        ////////////
            IGetFamilyMemberRelationsListService getFamilyMemberRelationsListService,
            IInsertFamilyMemberRelationService insertFamilyMemberRelationService,
            IUpdateFamilyMemberRelationService updateFamilyMemberRelationService,
            IGetFamilyMemberRelationUsesListService getFamilyMemberRelationUsesListService,
            IRemoveFamilyMemberRelationService removeFamilyMemberRelationService,
            IReOrderFamilyMemberRelationService reOrderFamilyMemberRelationService,
        ////////////
            IGetFamilyMembersListService getFamilyMembersListService,
            IGetFamilyMemberByIdService getFamilyMemberByIdService,
            IInsertFamilyMemberService insertFamilyMemberService,
            IUpdateFamilyMemberService updateFamilyMemberService,
            IRemoveFamilyMemberService removeFamilyMemberService
            ) {
            this.getFamiliesListService = getFamiliesListService;
            this.insertFamilyService = insertFamilyService;
            this.getFamilyByIdService = getFamilyByIdService;
            this.updateFamilyService = updateFamilyService;
            this.removeFamilyService = removeFamilyService;
            this.getFamilyNeedsListService = getFamilyNeedsListService;
            this.insertFamilyNeedService = insertFamilyNeedService;
            this.updateFamilyNeedService = updateFamilyNeedService;
            this.removeFamilyNeedService = removeFamilyNeedService;
            this.reOrderFamilyNeedService = reOrderFamilyNeedService;
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
            this.removeFamilyNeedSubjectService = removeFamilyNeedSubjectService;
            this.getFamilyMemberNeedSubjectsListService = getFamilyMemberNeedSubjectsListService;
            this.insertFamilyMemberNeedSubjectService = insertFamilyMemberNeedSubjectService;
            this.updateFamilyMemberNeedSubjectService = updateFamilyMemberNeedSubjectService;
            this.getFamilyMemberNeedSubjectUsesListService = getFamilyMemberNeedSubjectUsesListService;
            this.removeFamilyMemberNeedSubjectService = removeFamilyMemberNeedSubjectService;
            this.getFamilyMemberSpecialDiseaseSubjectsListService = getFamilyMemberSpecialDiseaseSubjectsListService;
            this.insertFamilyMemberSpecialDiseaseSubjectService = insertFamilyMemberSpecialDiseaseSubjectService;
            this.updateFamilyMemberSpecialDiseaseSubjectService = updateFamilyMemberSpecialDiseaseSubjectService;
            this.getFamilyMemberSpecialDiseaseSubjectUsesListService = getFamilyMemberSpecialDiseaseSubjectUsesListService;
            this.removeFamilyMemberSpecialDiseaseSubjectService = removeFamilyMemberSpecialDiseaseSubjectService;
            this.getFamilyMemberRelationsListService = getFamilyMemberRelationsListService;
            this.insertFamilyMemberRelationService = insertFamilyMemberRelationService;
            this.updateFamilyMemberRelationService = updateFamilyMemberRelationService;
            this.getFamilyMemberRelationUsesListService = getFamilyMemberRelationUsesListService;
            this.removeFamilyMemberRelationService = removeFamilyMemberRelationService;
            this.reOrderFamilyMemberRelationService = reOrderFamilyMemberRelationService;
            this.getFamilyMembersListService = getFamilyMembersListService;
            this.getFamilyMemberByIdService = getFamilyMemberByIdService;
            this.insertFamilyMemberService = insertFamilyMemberService;
            this.updateFamilyMemberService = updateFamilyMemberService;
            this.removeFamilyMemberService = removeFamilyMemberService;
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

        [HttpDelete]
        public async Task<bool> Remove([FromQuery] int id) {
            return await removeFamilyService.Exe(id);
        }

        ////////////

        [HttpGet]
        public async Task<List<GetFamilyNeedsListItemDto>> FamilyNeeds([FromQuery] int familyId) {
            return await getFamilyNeedsListService.Exe(familyId);
        }

        [HttpPost]
        public async Task<int> AddFamilyNeed([FromBody] InsertFamilyNeedDto dto) {
            return await insertFamilyNeedService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditFamilyNeed([FromBody] UpdateFamilyNeedDto dto) {
            return await updateFamilyNeedService.Exe(dto);
        }

        [HttpDelete]
        public async Task<bool> RemoveFamilyNeed([FromQuery] int id) {
            return await removeFamilyNeedService.Exe(id);
        }

        [HttpPut]
        public async Task<bool> ReOrderFamilyNeeds([FromBody] ReOrderFamilyNeedDto dto) {
            return await reOrderFamilyNeedService.Exe(dto);
        }

        ////////////

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
        public async Task<WithPagination<GetUsesListFamilyItemDto>> FamilyLevelUsesList([FromQuery] GetUsesListQuery query) {
            return await getFamilyLevelUsesListService.Exe(query);
        }

        [HttpDelete]
        public async Task<bool> RemoveFamilyLevel([FromQuery] int id) {
            return await removeFamilyLevelService.Exe(id);
        }

        ////////////

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
        public async Task<WithPagination<GetUsesListFamilyItemDto>> ConnectorUsesList([FromQuery] GetUsesListQuery query) {
            return await getConnectorUsesListService.Exe(query);
        }

        [HttpDelete]
        public async Task<bool> RemoveConnector([FromQuery] int id) {
            return await removeConnectorService.Exe(id);
        }

        ////////////

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

        [HttpDelete]
        public async Task<bool> RemoveFamilyNeedSubject([FromQuery] int id) {
            return await removeFamilyNeedSubjectService.Exe(id);
        }

        ////////////

        [HttpGet]
        public async Task<List<FamilyMemberNeedSubject>> FamilyMemberNeedSubjects() {
            return await getFamilyMemberNeedSubjectsListService.Exe();
        }

        [HttpPost]
        public async Task<int> AddFamilyMemberNeedSubject([FromBody] InsertFamilyMemberNeedSubjectDto dto) {
            return await insertFamilyMemberNeedSubjectService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditFamilyMemberNeedSubject([FromBody] FamilyMemberNeedSubject dto) {
            return await updateFamilyMemberNeedSubjectService.Exe(dto);
        }

        [HttpGet]
        public async Task<WithPagination<GetUsesListFamilyMemberItemDto>> FamilyMemberNeedSubjectUsesList([FromQuery] GetUsesListQuery query) {
            return await getFamilyMemberNeedSubjectUsesListService.Exe(query);
        }

        [HttpDelete]
        public async Task<bool> RemoveFamilyMemberNeedSubject([FromQuery] int id) {
            return await removeFamilyMemberNeedSubjectService.Exe(id);
        }

        ////////////

        [HttpGet]
        public async Task<List<FamilyMemberSpecialDiseaseSubject>> FamilyMemberSpecialDiseaseSubjects() {
            return await getFamilyMemberSpecialDiseaseSubjectsListService.Exe();
        }

        [HttpPost]
        public async Task<int> AddFamilyMemberSpecialDiseaseSubject([FromBody] InsertFamilyMemberSpecialDiseaseSubjectDto dto) {
            return await insertFamilyMemberSpecialDiseaseSubjectService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditFamilyMemberSpecialDiseaseSubject([FromBody] FamilyMemberSpecialDiseaseSubject dto) {
            return await updateFamilyMemberSpecialDiseaseSubjectService.Exe(dto);
        }

        [HttpGet]
        public async Task<WithPagination<GetUsesListFamilyMemberItemDto>> FamilyMemberSpecialDiseaseSubjectUsesList([FromQuery] GetUsesListQuery query) {
            return await getFamilyMemberSpecialDiseaseSubjectUsesListService.Exe(query);
        }

        [HttpDelete]
        public async Task<bool> RemoveFamilyMemberSpecialDiseaseSubject([FromQuery] int id) {
            return await removeFamilyMemberSpecialDiseaseSubjectService.Exe(id);
        }

        ////////////

        [HttpGet]
        public async Task<List<FamilyMemberRelation>> FamilyMemberRelations() {
            return await getFamilyMemberRelationsListService.Exe();
        }

        [HttpPost]
        public async Task<int> AddFamilyMemberRelation([FromBody] InsertFamilyMemberRelationDto dto) {
            return await insertFamilyMemberRelationService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditFamilyMemberRelation([FromBody] FamilyMemberRelation dto) {
            return await updateFamilyMemberRelationService.Exe(dto);
        }

        [HttpGet]
        public async Task<WithPagination<GetUsesListFamilyMemberItemDto>> FamilyMemberRelationUsesList([FromQuery] GetUsesListQuery query) {
            return await getFamilyMemberRelationUsesListService.Exe(query);
        }

        [HttpDelete]
        public async Task<bool> RemoveFamilyMemberRelation([FromQuery] int id) {
            return await removeFamilyMemberRelationService.Exe(id);
        }

        [HttpPut]
        public async Task<bool> ReOrderFamilyMemberRelations([FromBody] ReOrderFamilyMemberRelationDto dto) {
            return await reOrderFamilyMemberRelationService.Exe(dto);
        }

        ////////////

        [HttpGet]
        public async Task<List<GetFamilyMembersItemDto>> MembersList([FromQuery] int familyId) {
            return await getFamilyMembersListService.Exe(familyId);
        }

        [HttpGet]
        public async Task<GetFamilyMemberDto> MemberSingle([FromQuery] int id) {
            return await getFamilyMemberByIdService.Exe(id);
        }

        [HttpPost]
        public async Task<int> AddMember([FromBody] InsertFamilyMemberDto dto) {
            return await insertFamilyMemberService.Exe(dto);
        }


        [HttpPut]
        public async Task<bool> EditMember([FromBody] UpdateFamilyMemberDto dto) {
            return await updateFamilyMemberService.Exe(dto);
        }

        [HttpDelete]
        public async Task<bool> RemoveMember([FromQuery] int id) {
            return await removeFamilyMemberService.Exe(id);
        }
    }
}
