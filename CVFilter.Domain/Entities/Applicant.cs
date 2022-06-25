using CVFilter.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CVFilter.Domain.Entities
{
    public class Applicant : BaseEntity
    {
        [Required(ErrorMessage = "Matches is Required")]
        public string Matches { get; set; }
        [Required(ErrorMessage = "Path is Required")]
        public string Path { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalExperience { get; set; }
        public ICollection<ApplicantEducationRelation> ApplicantEducationRelations { get; set; }
        public ICollection<ApplicantLanguageRelation> ApplicantLanguagesRelations { get; set; }
    }
}
