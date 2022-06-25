using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class BulkCreateApplicantCommandRequest : ICommandRequest<BulkCreateApplicantCommandResponse>
    {
        public BulkCreateApplicantCommandRequest()
        {
            CreateApplicants = new List<CreateApplicantCommandRequest>();
        }
        public List<CreateApplicantCommandRequest> CreateApplicants { get; set; }
    }
}
