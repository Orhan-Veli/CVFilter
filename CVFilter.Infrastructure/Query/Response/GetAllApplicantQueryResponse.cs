using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Query.Response
{
    public class GetAllApplicantQueryResponse
    {
        public GetAllApplicantQueryResponse()
        {
            GetApplicantQueryResponses = new List<GetApplicantQueryResponse>();
        }
        public string Errors { get; set; }
        public List<GetApplicantQueryResponse> GetApplicantQueryResponses { get; set; }
    }
}
