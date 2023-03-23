using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Candidate
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(512)]
        public string Email { get; set; }

        [MaxLength(2048)]
        public string? ResumeURL { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<Submissions> Submissions { get; set;}

    }

}
