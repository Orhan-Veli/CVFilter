using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Query.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Query.Request
{
    public class GetAllApplicantQueryRequest : IQueryRequest<GetAllApplicantQueryResponse>
    {
        public string User { get; set; }
    }
}
