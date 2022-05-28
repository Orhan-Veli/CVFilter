using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Application.Dto
{
    public class UpdateApplicantCommandRequestDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Matches { get; set; }
        public string Name { get; set; }
    }
}
