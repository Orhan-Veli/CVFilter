using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Command.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Request
{
    public class DeleteApplicantCommandRequest : ICommandRequest<DeleteApplicantCommandResponse>
    {
        public int Id { get; set; }
    }
}
