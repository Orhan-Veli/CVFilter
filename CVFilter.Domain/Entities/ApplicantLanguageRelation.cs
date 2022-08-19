using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CVFilter.Domain.Entities
{
    public class ApplicantLanguageRelation
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "ApplicantId is Required")]
        public int ApplicantId { get; set; }
        [Required(ErrorMessage = "Langugage is Required")]
        public string Langugage { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}
