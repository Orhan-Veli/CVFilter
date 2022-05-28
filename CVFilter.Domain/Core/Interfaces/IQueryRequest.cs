using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.Interfaces
{
    public interface IQueryRequest<TResponse> : IRequest<TResponse>
    {
    }
}
