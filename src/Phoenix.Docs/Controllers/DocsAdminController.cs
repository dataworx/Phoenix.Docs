using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Docs.Controllers
{
    [ApiController]
    [Route("phoenix/api/docs")]
    public class DocsAdminController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> CreateDocs()
        {
            return "Running.";
        }
    }
}
