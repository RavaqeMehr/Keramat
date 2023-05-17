using Entities.Services;
using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using Services.Services;
using Services.Services.Models;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class ServicesController : BaseApi {
        private readonly IGetServiceSubjectsListService getServiceSubjectsListService;
        private readonly IGetServiceSubjectUsesListService getServiceSubjectUsesListService;
        private readonly IInsertServiceSubjectService insertServiceSubjectService;
        private readonly IUpdateServiceSubjectService updateServiceSubjectService;
        private readonly IRemoveServiceSubjectService removeServiceSubjectService;
        private readonly IGetServiceProvidedsListService getServiceProvidedsListService;
        private readonly IGetServiceProvidedByIdService getServiceProvidedByIdService;
        private readonly IGetServiceProvidedListByFamilyService getServiceProvidedListByFamilyService;
        private readonly IInsertServiceProvidedService insertServiceProvidedService;
        private readonly IUpdateServiceProvidedService updateServiceProvidedService;
        private readonly IRemoveServiceProvidedService removeServiceProvidedService;
        private readonly IGetServiceReciversListService getServiceReciversListService;
        private readonly IInsertServiceReciverService insertServiceReciverService;
        private readonly IUpdateServiceReciverService updateServiceReciverService;
        private readonly IRemoveServiceReciverService removeServiceReciverService;
        private readonly IGetFamiliesReciveStatusService getFamiliesReciveStatusService;

        public ServicesController(
            IGetServiceSubjectsListService getServiceSubjectsListService,
            IGetServiceSubjectUsesListService getServiceSubjectUsesListService,
            IInsertServiceSubjectService insertServiceSubjectService,
            IUpdateServiceSubjectService updateServiceSubjectService,
            IRemoveServiceSubjectService removeServiceSubjectService,
        ////////////
            IGetServiceProvidedsListService getServiceProvidedsListService,
            IGetServiceProvidedByIdService getServiceProvidedByIdService,
            IGetServiceProvidedListByFamilyService getServiceProvidedListByFamilyService,
            IInsertServiceProvidedService insertServiceProvidedService,
            IUpdateServiceProvidedService updateServiceProvidedService,
            IRemoveServiceProvidedService removeServiceProvidedService,
        ////////////
            IGetServiceReciversListService getServiceReciversListService,
            IInsertServiceReciverService insertServiceReciverService,
            IUpdateServiceReciverService updateServiceReciverService,
            IRemoveServiceReciverService removeServiceReciverService,
            IGetFamiliesReciveStatusService getFamiliesReciveStatusService
            ) {
            this.getServiceSubjectsListService = getServiceSubjectsListService;
            this.getServiceSubjectUsesListService = getServiceSubjectUsesListService;
            this.insertServiceSubjectService = insertServiceSubjectService;
            this.updateServiceSubjectService = updateServiceSubjectService;
            this.removeServiceSubjectService = removeServiceSubjectService;
            this.getServiceProvidedsListService = getServiceProvidedsListService;
            this.getServiceProvidedByIdService = getServiceProvidedByIdService;
            this.getServiceProvidedListByFamilyService = getServiceProvidedListByFamilyService;
            this.insertServiceProvidedService = insertServiceProvidedService;
            this.updateServiceProvidedService = updateServiceProvidedService;
            this.removeServiceProvidedService = removeServiceProvidedService;
            this.getServiceReciversListService = getServiceReciversListService;
            this.insertServiceReciverService = insertServiceReciverService;
            this.updateServiceReciverService = updateServiceReciverService;
            this.removeServiceReciverService = removeServiceReciverService;
            this.getFamiliesReciveStatusService = getFamiliesReciveStatusService;
        }

        [HttpGet]
        public async Task<List<ServiceSubject>> Subjects() {
            return await getServiceSubjectsListService.Exe();
        }

        [HttpGet]
        public async Task<WithPagination<ServiceSubjectGetUsesListItemDto>> SubjectsUsesList([FromQuery] GetListQuery query) {
            return await getServiceSubjectUsesListService.Exe(query);
        }

        [HttpPost]
        public async Task<int> AddSubject([FromBody] ServiceSubjectInsertDto dto) {
            return await insertServiceSubjectService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditSubject([FromBody] ServiceSubject dto) {
            return await updateServiceSubjectService.Exe(dto);
        }

        [HttpDelete]
        public async Task<bool> RemoveSubject([FromQuery] int id) {
            return await removeServiceSubjectService.Exe(id);
        }

        ////////////

        [HttpGet]
        public async Task<WithPagination<ServiceProvidedGetListItemDto>> Provided([FromQuery] int page) {
            return await getServiceProvidedsListService.Exe(page);
        }

        [HttpGet]
        public async Task<ServiceProvidedDto> ProvidedSingle([FromQuery] int id) {
            return await getServiceProvidedByIdService.Exe(id);
        }

        [HttpGet]
        public async Task<WithPagination<ServiceProvidedGetListByFamilyItemDto>> ProvidedToFamily([FromQuery] GetListQuery query) {
            return await getServiceProvidedListByFamilyService.Exe(query);
        }

        [HttpPost]
        public async Task<int> AddProvided([FromBody] ServiceProvidedDto dto) {
            return await insertServiceProvidedService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditProvided([FromBody] ServiceProvidedUpdateDto dto) {
            return await updateServiceProvidedService.Exe(dto);
        }

        [HttpDelete]
        public async Task<bool> RemoveProvided([FromQuery] int id) {
            return await removeServiceProvidedService.Exe(id);
        }


        ////////////

        [HttpGet]
        public async Task<WithPagination<ServiceReciverGetListItemDto>> Recivers([FromQuery] GetListQuery query) {
            return await getServiceReciversListService.Exe(query);
        }

        [HttpPost]
        public async Task<int> AddReciver([FromBody] ServiceReciverInsertDto dto) {
            return await insertServiceReciverService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditReciver([FromBody] ServiceReciverUpdateDto dto) {
            return await updateServiceReciverService.Exe(dto);
        }

        [HttpDelete]
        public async Task<bool> RemoveReciver([FromQuery] int id) {
            return await removeServiceReciverService.Exe(id);
        }

        [HttpGet]
        public async Task<List<GetAllNotRecivedFamiliesItemDto>> FamiliesStatus([FromQuery] int id) {
            return await getFamiliesReciveStatusService.Exe(id);
        }
    }
}
