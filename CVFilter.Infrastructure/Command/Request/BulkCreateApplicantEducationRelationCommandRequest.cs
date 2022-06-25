using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class BulkCreateApplicantEducationRelationCommandRequest : ICommandRequest<BulkCreateApplicantEducationRelationCommandResponse>
    {
        public BulkCreateApplicantEducationRelationCommandRequest()
        {
            CreateApplicantEducationRelations = new List<CreateApplicantEducationRelationCommandRequest>();
        }
        public List<CreateApplicantEducationRelationCommandRequest> CreateApplicantEducationRelations { get; set; }
    }
}
