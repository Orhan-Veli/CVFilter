using CVFilter.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CVFilter.Domain.Entities
{
    public class ApplicantEducationRelation
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "ApplicantId is Required")]
        public int ApplicantId { get; set; }
        [Required(ErrorMessage = "SchoolName is Required")]
        public string SchoolName { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
