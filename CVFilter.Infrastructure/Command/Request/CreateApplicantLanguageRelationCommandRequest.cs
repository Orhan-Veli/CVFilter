using CVFilter.Domain.Core.Interfaces;
using CVFilter.Domain.Entities.Base;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class CreateApplicantLanguageRelationCommandRequest : ICommandRequest<CreateApplicantLanguageRelationCommandResponse>
    {
        public int ApplicantId { get; set; }
        public string Language { get; set; }
    }
}
