using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Application.Dto
{
    public class CreateApplicantCommandRequestDto
    {
        public string Matches { get; set; }
        public string Path { get; set; }
    }
}
