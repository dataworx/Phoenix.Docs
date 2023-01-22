using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AspNetRazorPagesDocsSample.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger logger = Log.ForContext<PrivacyModel>();

        public PrivacyModel()
        {
        }

        public void OnGet()
        {
        }
    }
}