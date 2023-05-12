using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using Services.Kheyrat;
using Services.Kheyrat.Models;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class KheyratController : BaseApi {
        private readonly IGetNikooKarsListService getNikooKarsListService;
        private readonly IGetNikooKarByIdService getNikooKarByIdService;
        private readonly IInsertNikooKarService insertNikooKarService;
        private readonly IUpdateNikooKarService updateNikooKarService;
        private readonly IRemoveNikooKarService removeNikooKarService;
        private readonly IGetKheyrsListService getKheyrsListService;
        private readonly IGetKheyrByIdService getKheyrByIdService;
        private readonly IInsertKheyrService insertKheyrService;
        private readonly IUpdateKheyrService updateKheyrService;
        private readonly IRemoveKheyrService removeKheyrService;

        public KheyratController(
            IGetNikooKarsListService getNikooKarsListService,
            IGetNikooKarByIdService getNikooKarByIdService,
            IInsertNikooKarService insertNikooKarService,
            IUpdateNikooKarService updateNikooKarService,
            IRemoveNikooKarService removeNikooKarService,
        ////////////
            IGetKheyrsListService getKheyrsListService,
            IGetKheyrByIdService getKheyrByIdService,
            IInsertKheyrService insertKheyrService,
            IUpdateKheyrService updateKheyrService,
            IRemoveKheyrService removeKheyrService
            ) {
            this.getNikooKarsListService = getNikooKarsListService;
            this.getNikooKarByIdService = getNikooKarByIdService;
            this.insertNikooKarService = insertNikooKarService;
            this.updateNikooKarService = updateNikooKarService;
            this.removeNikooKarService = removeNikooKarService;
            this.getKheyrsListService = getKheyrsListService;
            this.getKheyrByIdService = getKheyrByIdService;
            this.insertKheyrService = insertKheyrService;
            this.updateKheyrService = updateKheyrService;
            this.removeKheyrService = removeKheyrService;
        }

        [HttpGet]
        public async Task<WithPagination<GetNikooKarsListItemDto>> NikooKaran([FromQuery] GetNikooKarsListQuery query) {
            return await getNikooKarsListService.Search(query);
        }

        [HttpGet]
        public async Task<NikooKarDto> NikooKar([FromQuery] int id) {
            return await getNikooKarByIdService.Exe(id);
        }

        [HttpPost]
        public async Task<int> AddNikooKar([FromBody] NikooKarDto dto) {
            return await insertNikooKarService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditNikooKar([FromQuery] int id, [FromBody] NikooKarDto dto) {
            return await updateNikooKarService.Exe(id, dto);
        }

        [HttpDelete]
        public async Task<bool> RemoveNikooKar([FromQuery] int id) {
            return await removeNikooKarService.Exe(id);
        }

        ////////////

        [HttpGet]
        public async Task<WithPagination<GetKheyrsListItemDto>> Kheyrat([FromQuery] GetKheyrsListQuery query) {
            return await getKheyrsListService.Exe(query);
        }

        [HttpGet]
        public async Task<KheyrDto> Kheyr([FromQuery] int id) {
            return await getKheyrByIdService.Exe(id);
        }

        [HttpPost]
        public async Task<int> AddKheyr([FromBody] KheyrInsertDto dto) {
            return await insertKheyrService.Exe(dto);
        }

        [HttpPut]
        public async Task<bool> EditKheyr([FromBody] KheyrUpdateDto dto) {
            return await updateKheyrService.Exe(dto);
        }

        [HttpDelete]
        public async Task<bool> RemoveKheyr([FromQuery] int id) {
            return await removeKheyrService.Exe(id);
        }

    }
}
