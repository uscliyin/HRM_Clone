using Microsoft.AspNetCore.Mvc;

namespace OnBoarding.API.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
