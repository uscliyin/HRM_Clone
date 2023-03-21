using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;

namespace ApplicationCore.Models
{
    public class JobRequestModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Please enter Title of the job")]
        [StringLength(256)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter Job Description")]
        [StringLength(5000)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please enter number")]
        public int NumberOfPostions { get; set; }

        public int JobStatusLookUpId { get; set; }
    }
}
