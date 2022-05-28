using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.ServiceResponse.Base
{
    public interface IServiceResponse<T>
    {
        int HttpResponse { get; set; }
        bool Status { get; set; }
        T Data { get; set; }
    }
}
