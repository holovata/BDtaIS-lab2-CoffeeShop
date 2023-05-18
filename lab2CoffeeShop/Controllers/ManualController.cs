using Microsoft.AspNetCore.Mvc;

namespace lab2CoffeeShop.Controllers
{
    public class ManualController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
