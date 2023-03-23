using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class SubmissionsRequestModel
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? SubmittedOn { get; set; }
    }
}
