using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService _submissionsService;
        public SubmissionsController(ISubmissionsService submissionsService)
        {

            _submissionsService = submissionsService;

        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            //var job = _submissionsService.GetJobById(id);

            //var model = new SubmissionsRequestModel
            //{
            //    JobId = job.Id,
            //    JobCode = job.JobCode,
            //    Title = job.Title
            //};
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(SubmissionsRequestModel model,int id)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            int jobId = id;
            await _submissionsService.AddCandidate(model, jobId);
            return Redirect("/Jobs/Index");

        }
    }
}
