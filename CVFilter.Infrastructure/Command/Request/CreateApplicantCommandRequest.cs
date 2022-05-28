using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class CreateApplicantCommandRequest : ICommandRequest<CreateApplicantCommandResponse>
    {
        public CreateApplicantCommandRequest()
        {
            IsDeleted = false;
            IsActive = true;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        public string Name { get; set; }
        public string User { get; set; }
        public string Matches { get; set; }
        public string Path { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
