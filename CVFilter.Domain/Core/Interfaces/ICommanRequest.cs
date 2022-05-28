using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.Interfaces
{
    public interface ICommandRequest<TResponse> : IRequest<TResponse>
    {
    }
}
