using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SubmissionsService : ISubmissionsService
    {

        private readonly ISubmissionsRepository _submissionsRepository;
        public SubmissionsService(ISubmissionsRepository submissionsRepository)
        {
            _submissionsRepository = submissionsRepository;
        }
        public async Task<int> AddCandidate(SubmissionsRequestModel model,int jobId)
        {
            
            var submissionsEntity = new Submissions
            {
                
                JobId = jobId,
                CandidateId = 1,
                SubmittedOn = DateTime.UtcNow,
                SelectedForInterview= DateTime.UtcNow,
                RejectedOn = DateTime.UtcNow,

            };

            var candidateEntity = new Candidate
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };

            var submissions = await _submissionsRepository.AddAsync(submissionsEntity);
            //?

            return submissions.Id;
        }
    }
}
