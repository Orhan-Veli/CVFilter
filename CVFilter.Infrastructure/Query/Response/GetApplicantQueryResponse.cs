using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Query.Response
{
    public class GetApplicantQueryResponse
    {
        public int Id { get; set; }
        public string Matches { get; set; }
        public string Path { get; set; }
        public string User { get; set; }

        public string Error { get; set; }
    }
}
