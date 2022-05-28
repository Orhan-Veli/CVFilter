using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Command.Response
{
    public class DeleteApplicantCommandResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
