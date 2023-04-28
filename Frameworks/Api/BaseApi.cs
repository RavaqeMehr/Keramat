using Frameworks.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frameworks.Api {
    [AllowAnonymous]
    //[Area("api")]
    [ApiController]
    [ApiResultFilter]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]// api/v1/[controller]/[action]
    //[Route("api/{namespace}/[controller]/[action]")]// api/v1/[controller]/[action]
    public class BaseApi : ControllerBase {
        //public bool IsAuthenticated => HttpContext.User.Identity?.IsAuthenticated ?? false;
        //public int thisUserId => HttpContext.User.Identity?.GetUserId<int>() ?? -1;
    }
}
