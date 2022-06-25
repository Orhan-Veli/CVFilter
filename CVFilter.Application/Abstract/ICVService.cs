using CVFilter.Application.Dto;
using CVFilter.Domain.Core.ServiceResponse.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CVFilter.Application.Abstract
{
    public interface ICVService
    {
        Task<IServiceResponse<string>> CVWorkerAsync(CVWorkerRequestDto cVWorkerRequestDto);
    }
}
