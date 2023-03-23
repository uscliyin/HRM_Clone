using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Submissions
    {
        public int Id { get; set; }

        public int JobId { get; set; }
        public int CandidateId { get; set; }

        public DateTime? SubmittedOn { get; set; }
        public DateTime? SelectedForInterview { get; set; }
        public DateTime? RejectedOn { get; set; }

        public Job Job { get; set; }
        public Candidate Candidate { get; set; }
    }
}
