using CVFilter.Application.Dto;
using CVFilter.Domain.Core.ServiceResponse.Base;
using CVFilter.Infrastructure.Command.Response;
using CVFilter.Infrastructure.Query.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CVFilter.Application.Abstract
{
    public interface IApplicantService
    {
        Task<IServiceResponse<CreateApplicantCommandResponse>> CreateAsync(CreateApplicantCommandRequestDto createApplicantCommandRequestDto);
        Task<IServiceResponse<UpdateApplicantCommandResponse>> UpdateAsync(UpdateApplicantCommandRequestDto updateApplicantCommandResponseDto);
        Task<IServiceResponse<DeleteApplicantCommandResponse>> DeleteAsync(DeleteApplicantCommandRequestDto deleteApplicantCommandRequestDto);
        Task<IServiceResponse<GetApplicantQueryResponse>> GetAsync(GetApplicantQueryRequestDto getApplicantQueryRequestDto);
        Task<IServiceResponse<GetAllApplicantQueryResponse>> GetAllAsync(GetAllApplicantQueryRequestDto getAllApplicantQueryRequestDto);
    }
}
