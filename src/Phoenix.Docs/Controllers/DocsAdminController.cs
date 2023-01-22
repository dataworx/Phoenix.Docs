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
        private readonly DocsOptions options;

        #endregion

        #region Constructors

        public DocsAdminController(IDocsCreationService docsCreationService, IOptions<DocsOptions> options)
        {
            this.docsCreationService = docsCreationService;
            this.options = options.Value;
        } 
        
        #endregion

        [HttpPost("shortName")]
        public async Task<ActionResult<string>> CreateDocs(string shortName)
        {
            var project = this.options.Projects.SingleOrDefault(x =>
                x.ShortName.Equals(shortName, StringComparison.InvariantCultureIgnoreCase));

            if (project == null)
            {
                return NotFound();
            }

            var result = await this.docsCreationService.CreateDocs(options, project);
            if (result.Succees)
            {
                return Created(result.Value, null);
            }

            return StatusCode((int)HttpStatusCode.InternalServerError, result.Error);
        }
    }
}
