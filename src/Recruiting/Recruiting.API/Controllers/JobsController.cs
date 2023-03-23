using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //http"localhost/api/jobs

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();
            //return Json data
            //serialization C# objects into Json Objects using System.Text
            if (!jobs.Any())
            {
                return NotFound(new { error = "No open Jobs found, please try later" });

            }
            return Ok(jobs);
        }

        //http"localhost/api/jobs/4
        [HttpGet]
        [Route("{id:int}", Name="GetJobDetails")]
        
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job= await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new { errorMessage = "No Job found fot this id" });

            }
            return Ok(job);
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var job=await _jobService.AddJob(model);
            return CreatedAtAction("GetJobDetails", new {controller="Jobs",id=job},"Job Created");
        }
    }
}
