using CVFilter.Domain.Core.Interfaces;
using CVFilter.Domain.Entities.Base;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class CreateApplicantEducationRelationCommandRequest : ICommandRequest<CreateApplicantEducationRelationCommandResponse>
    {
        public int ApplicantId { get; set; }
        public string SchoolName { get; set; }
    }
}
