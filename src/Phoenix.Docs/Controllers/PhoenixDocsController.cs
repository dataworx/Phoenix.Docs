using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Phoenix.Docs.Controllers;

public class PhoenixDocsController : Controller
{
    public async Task<string> Index(string projectShortName = "", string filePath = "")
    {
        return $"Processing request to {projectShortName}/{filePath}";
    }
}