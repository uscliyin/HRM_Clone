using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SubmissonsRepository : BaseRepository<Submissions>, ISubmissionsRepository
    {
        private RecruitingDbContext _dbContext;
        public SubmissonsRepository(RecruitingDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
