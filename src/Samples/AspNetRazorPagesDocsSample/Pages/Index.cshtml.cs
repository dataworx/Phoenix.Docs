using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Phoenix.Docs.Publish;
using Serilog;

namespace AspNetRazorPagesDocsSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger logger = Log.ForContext<IndexModel>();
        
        public string Message { get; set; }

        private IPublisher publisher;

        public IndexModel(IPublisher publisher)
        {
            this.publisher = publisher;
        }

        public async Task OnPost()
        {
            var result = await this.publisher.Publish();
            if (result.Success)
            {
                Message = "Documentation generated successfully";
            }
            else
            {
                Message = string.Join("<br/>", result.Errors.Select(x => x.ErrorMessage));
            }
        }

        public void OnGet()
        {

        }
    }
}