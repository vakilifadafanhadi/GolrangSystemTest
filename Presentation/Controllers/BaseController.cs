using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class BaseController : ControllerBase
    {
        internal Guid GetUserId() =>
            Guid.Parse(HttpContext.User.Claims.FirstOrDefault().Value);
    }
}
