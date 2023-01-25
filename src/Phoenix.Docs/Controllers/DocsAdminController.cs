using Microsoft.AspNetCore.Mvc;
using Phoenix.Docs.AppServices;
using Phoenix.Docs.Errors;
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

        [HttpPost("{shortName}")]
        public async Task<ActionResult<string>> CreateDocs(string shortName)
        {
            var result = await this.docsCreationService.CreateDocs(shortName);
            
            if (result.Success)
            {
                return Created(result.Value, null);
            }

            if (result.Error != null)
            {
                switch (result.Error.ErrorCode)
                {
                    case ErrorCode.NotFound:
                        return NotFound();
                    default:
                        return StatusCode((int)HttpStatusCode.InternalServerError, result.Error.ErrorMessage);
                }
                
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
