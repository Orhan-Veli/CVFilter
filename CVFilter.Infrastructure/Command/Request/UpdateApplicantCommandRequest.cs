using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class UpdateApplicantCommandRequest : ICommandRequest<UpdateApplicantCommandResponse>
    {
        public UpdateApplicantCommandRequest()
        {
            UpdatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Matches { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalExperience { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
