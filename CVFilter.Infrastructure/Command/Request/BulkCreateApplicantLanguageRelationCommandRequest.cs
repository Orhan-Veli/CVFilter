using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class BulkCreateApplicantLanguageRelationCommandRequest : ICommandRequest<BulkCreateApplicantLanguageRelationCommandResponse>
    {
        public BulkCreateApplicantLanguageRelationCommandRequest()
        {
            CreateApplicantLanguageRelations = new List<CreateApplicantLanguageRelationCommandRequest>();
        }
        public List<CreateApplicantLanguageRelationCommandRequest> CreateApplicantLanguageRelations { get; set; }
    }
}
