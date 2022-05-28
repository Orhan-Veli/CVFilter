using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.Interfaces
{
    public interface IQueryRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQueryRequest<TResponse>
    {
    }
}
