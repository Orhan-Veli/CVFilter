using System;
using System.Collections.Generic;
using System.Text;
using CVFilter.Domain.Core.Interfaces;
using CVFilter.Domain.Entities.Base;
using CVFilter.Infrastructure.Command.Response;

namespace CVFilter.Infrastructure.Command.Request
{
    public class CreateLogCommandRequest : BaseEntity,ICommandRequest<CreateLogCommandResponse>
    {
        public string ErrorMessage { get; set; }
    }
}
