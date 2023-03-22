using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<int> AddJob(JobRequestModel model)
        {
            var jobEntity = new Job
            {
                Title = model.Title,
                StartDate = model.StartDate,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                NumberOfPositions = model.NumberOfPostions,
                JobStatusLookUpId = model.JobStatusLookUpId,

            };
            var job=await _jobRepository.AddAsync(jobEntity); 
            return job.Id;

        }

        public async Task<List<JobResponseModel>> GetAllJobs()
        {
            var jobs = await _jobRepository.GetAllJobs();
            var jobsResponseModel = new List<JobResponseModel>();
            foreach (var job in jobs)
            {
                jobsResponseModel.Add(new JobResponseModel
                {
                    Id = job.Id,
                    Description = job.Description,
                    Title = job.Title,
                    StartDate=job.StartDate.GetValueOrDefault(),
                    NumberOfPositions= job.NumberOfPositions
                    
                });
            }
            return jobsResponseModel;
            // have some dummy data
            // get the data from repositories and send he model info to controllers
        //    var jobs = new List<JobResponseModel>
        //{
        //    new() { Id = 1, Title = ".NET Developer", Description = "Need to be good with C# and EF Core and .NET" },
        //    new()
        //    {
        //        Id = 2, Title = "Full Stack .NET Developer",
        //        Description = "Need to be good with Typescript, C# and EF Core and .NET"
        //    },
        //    new() { Id = 3, Title = "Java Developer", Description = "Need to be good with Java" },
        //    new() { Id = 4, Title = "JavaScript Developer", Description = "Need to be good JavaScript" }
        //};

        //    return jobs;


            
        }

        //public async Task <JobResponseModel> GetJobById(int id)
        //{
        //    var job=await _jobRepository.GetJobById(id);
        //    var jobResponseModel=new JobResponseModel {

        //        Id = job.Id,
        //        Description = job.Description,
        //        Title = job.Title,
        //        StartDate = job.StartDate.GetValueOrDefault(),
        //        NumberOfPositions = job.NumberOfPositions
        //    };
        //    return jobResponseModel;
        //}

        public async Task<JobDetails> GetJobById(int id)
        {
            var job = await _jobRepository.GetJobById(id);
            if (job == null)
            {
                return null;
            }
            var jobDetails = new JobDetails
            {
                Id= job.Id,
                JobCode = job.JobCode,
                NumberOfPositions = job.NumberOfPositions,
                Description= job.Description,
                Title = job.Title,
                StartDate = job.StartDate.GetValueOrDefault(),
                IsActive= job.IsActive,
                CreatedOn= job.CreatedOn.GetValueOrDefault(),
                
            };
            return jobDetails;
        }
    }
}
