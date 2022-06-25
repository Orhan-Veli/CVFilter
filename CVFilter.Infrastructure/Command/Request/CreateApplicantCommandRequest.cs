using CVFilter.Domain.Core.Interfaces;
using CVFilter.Domain.Entities.Base;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class CreateApplicantCommandRequest : BaseEntity,ICommandRequest<CreateApplicantCommandResponse>
    {
        public string Matches { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalExperience { get; set; }
    }
}
