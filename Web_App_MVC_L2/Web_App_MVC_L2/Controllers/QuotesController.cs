using Microsoft.AspNetCore.Mvc;
using YourAppNamespace.Models;

namespace YourAppNamespace.Controllers
{
    public class QuotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
