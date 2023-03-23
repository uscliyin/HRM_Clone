using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class JobRepository :BaseRepository<Job>, IJobRepository
    {
        private RecruitingDbContext _dbContext;
        public JobRepository(RecruitingDbContext dbContext):base(dbContext) {

            _dbContext = dbContext;
        }
        public async Task<List<Job>> GetAllJobs()
        {

            //go to db and get the data;
            //EF core with LINQ
            var jobs= await _dbContext.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<Job> GetJobById(int id)
        {
            var job = await _dbContext.Jobs.FirstOrDefaultAsync(j=>j.Id==id);
            return job;
        }
    }
}
