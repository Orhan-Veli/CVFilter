using CVFilter.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CVFilter.Domain.Entities
{
    public class Applicant : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Matches is Required")]
        public string Matches { get; set; }
        [Required(ErrorMessage = "Path is Required")]
        public string Path { get; set; }
        [Required(ErrorMessage = "User is Required")]
        public string User { get; set; }
    }
}
