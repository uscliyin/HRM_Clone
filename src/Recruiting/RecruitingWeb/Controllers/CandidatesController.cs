using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class CandidatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
