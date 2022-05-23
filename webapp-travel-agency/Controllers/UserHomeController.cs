using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
