using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Controllers
{
    public class PersonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
