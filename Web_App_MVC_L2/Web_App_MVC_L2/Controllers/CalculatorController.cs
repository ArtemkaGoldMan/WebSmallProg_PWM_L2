using Microsoft.AspNetCore.Mvc;
using Web_App_MVC_L2.Models;

namespace Web_App_MVC_L2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            model.Calculate();
            return View(model);
        }
    }
}
