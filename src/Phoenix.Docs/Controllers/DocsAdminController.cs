using Microsoft.AspNetCore.Mvc;
using Phoenix.Docs.AppServices;
using System.Net;
using System.Threading.Tasks;

namespace Phoenix.Docs.Controllers
{
    [ApiController]
    [Route("phoenix/api/docs")]
    public class DocsAdminController : ControllerBase
    {
        #region Fields
        
        private readonly IDocsCreationService docsCreationService;

        #endregion

        #region Constructors

        public DocsAdminController(IDocsCreationService docsCreationService)
        {
            this.docsCreationService = docsCreationService;
        } 
        
        #endregion

        [HttpPost]
        public async Task<ActionResult<string>> CreateDocs(string project)
        {
            var result = await this.docsCreationService.CreateDocs(project);
            if (result.Succees)
            {
                return Created(result.Value, null);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, result.Error);
        }
    }
}
