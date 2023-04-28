using Frameworks.Api;
using Microsoft.AspNetCore.Mvc;

namespace KeramatWeb.Api.V1.Controllers {
    [ApiVersion("1")]
    public class HomeController : BaseApi {
        [HttpGet]
        public int Index() {
            return 786;
        }
    }
}
