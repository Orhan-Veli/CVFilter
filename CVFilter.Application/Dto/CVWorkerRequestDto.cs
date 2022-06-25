using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Application.Dto
{
    public class CVWorkerRequestDto
    {
        public string Path { get; set; }
        public string LanguageMatches { get; set; }
        public string EducationMatches { get; set; }
        public string RequiredMatches { get; set; }
        public int Experience { get; set; }
    }
}
