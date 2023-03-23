using Infrastructure.Services;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Models;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService) 
        {

            _jobService = jobService;

        }
        public async Task<IActionResult> Index()
       
        {
            // 3 ways we can send data from controller/actionb method to view
            // 1. ViewBag
            // 2. ViewData

            // 3. *** Strongly Typed Model data *****
            ViewBag.PageTitle = "Showing Jobs";
            var jobs = await _jobService.GetAllJobs();
            return View(jobs);
        }
        public async Task<IActionResult> Details(int id) 
        { 
            var job = await _jobService.GetJobById(id);
            return View(job);


        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // Saving the Job Infor
        public async Task<IActionResult>Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _jobService.AddJob(model);
            return RedirectToAction("Index");
        }

    }
}
