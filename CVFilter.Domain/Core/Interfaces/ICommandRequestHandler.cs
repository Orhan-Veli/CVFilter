using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.Interfaces
{
    public interface ICommandRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : ICommandRequest<TResponse>
    {
    }
}
