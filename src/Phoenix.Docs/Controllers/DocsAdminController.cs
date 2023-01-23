using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Phoenix.Docs.AppServices;
using Phoenix.Docs.Domain;
using System;
using System.Linq;
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

        [HttpPost("shortName")]
        public async Task<ActionResult<string>> CreateDocs(string shortName)
        {
            var result = await this.docsCreationService.CreateDocs(shortName);
            
            if (result.Succees)
            {
                return Created(result.Value, null);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, result.Error);
        }
    }
}
