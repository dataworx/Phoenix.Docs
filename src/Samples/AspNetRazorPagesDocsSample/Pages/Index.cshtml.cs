using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AspNetRazorPagesDocsSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger logger = Log.ForContext<IndexModel>();

        public IndexModel()
        {
        }

        public void OnGet()
        {

        }
    }
}