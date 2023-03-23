using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
        {

        }

        //DbSets are properties of DbContex


        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobStatusLookUp> JobStatusLookUp { get; set; }

        public DbSet<Submissions> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(ConfigureCandidate);
        }

        private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).HasMaxLength(100);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");
            
        }
    }
}
