using CVFilter.Application.Abstract;
using CVFilter.Application.Dto;
using CVFilter.Domain.Core.ServiceResponse;
using CVFilter.Domain.Core.ServiceResponse.Base;
using CVFilter.Infrastructure.Command.Response;
using CVFilter.Infrastructure.Query.Response;
using CVFilter.Domain.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CVFilter.Infrastructure.Command.Request;
using CVFilter.Infrastructure.Query.Request;
using System.Linq;
using Mapster;
using CVFilter.Infrastructure.UnitOfWork;
using CVFilter.Infrastructure.UnitOfWork.Base;

namespace CVFilter.Application.Concrete
{
    public class ApplicantService : IApplicantService
    {
        private readonly IMediator _mediatr;
        private readonly IUnitOfWork _uof;
        public ApplicantService(IMediator mediatr,IUnitOfWork uof)
        {
            _mediatr = mediatr;
            _uof = uof;
        }
        public async Task<IServiceResponse<CreateApplicantCommandResponse>> CreateAsync(CreateApplicantCommandRequestDto createApplicantCommandRequestDto)
        {
            if (createApplicantCommandRequestDto == null || string.IsNullOrEmpty(createApplicantCommandRequestDto.Path) || string.IsNullOrEmpty(createApplicantCommandRequestDto.Matches))
            {
                return new ServiceResponse<CreateApplicantCommandResponse>(400,false,"Create Applicant model is not valid");
            }

            var createApplicant = await _mediatr.Send(createApplicantCommandRequestDto.Adapt<CreateApplicantCommandRequest>());
            if (createApplicant.Id == -1)
            {
                return new ServiceResponse<CreateApplicantCommandResponse>(500, false, createApplicant.ErrorMessage);
            }
            _uof.Commit();
            return new ServiceResponse<CreateApplicantCommandResponse>(201, true, new CreateApplicantCommandResponse { Id = createApplicant.Id });
        }

        public async Task<IServiceResponse<DeleteApplicantCommandResponse>> DeleteAsync(DeleteApplicantCommandRequestDto deleteApplicantCommandRequestDto)
        {
            if (deleteApplicantCommandRequestDto == null || deleteApplicantCommandRequestDto.Id == 0)
            {
                return new ServiceResponse<DeleteApplicantCommandResponse>(400, false, "Delete Applicant model is not valid");
            }

            var deleteApplicant = await _mediatr.Send(deleteApplicantCommandRequestDto.Adapt<DeleteApplicantCommandRequest>());
            if (!deleteApplicant.Success)
            {
                return new ServiceResponse<DeleteApplicantCommandResponse>(500, false, deleteApplicant.ErrorMessage);
            }
            _uof.Commit();
            return new ServiceResponse<DeleteApplicantCommandResponse>(204, deleteApplicant.Success);
        }

        public async Task<IServiceResponse<GetAllApplicantQueryResponse>> GetAllAsync(GetAllApplicantQueryRequestDto getAllApplicantQueryRequestDto)
        {
            var getAllApplicant = await _mediatr.Send(getAllApplicantQueryRequestDto.Adapt<GetAllApplicantQueryRequest>());
            if (!getAllApplicant.GetApplicantQueryResponses.Any())
            {
                return new ServiceResponse<GetAllApplicantQueryResponse>(200, false, new GetAllApplicantQueryResponse());
            }
            return new ServiceResponse<GetAllApplicantQueryResponse>(200, true, getAllApplicant);
        }

        public async Task<IServiceResponse<GetApplicantQueryResponse>> GetAsync(GetApplicantQueryRequestDto getApplicantQueryRequestDto)
        {
            if (getApplicantQueryRequestDto == null || getApplicantQueryRequestDto.Id == 0)
            {
                return new ServiceResponse<GetApplicantQueryResponse>(400, false, "Get Applicant model is not valid");
            }

            var getApplicant = await _mediatr.Send(getApplicantQueryRequestDto.Adapt<GetApplicantQueryRequest>());
            if(getApplicant == null)
            {
                return new ServiceResponse<GetApplicantQueryResponse>(404, false, "Get Applicant Error");
            }
            return new ServiceResponse<GetApplicantQueryResponse>(200, true, getApplicant);
        }

        public async Task<IServiceResponse<UpdateApplicantCommandResponse>> UpdateAsync(UpdateApplicantCommandRequestDto updateApplicantCommandResponseDto)
        {
            if (updateApplicantCommandResponseDto == null || updateApplicantCommandResponseDto.Id==0 || string.IsNullOrEmpty(updateApplicantCommandResponseDto.Matches) || string.IsNullOrEmpty(updateApplicantCommandResponseDto.Path))
            {
                return new ServiceResponse<UpdateApplicantCommandResponse>(400, false, "Update model is not valid");
            }

            var updateApplicant = await _mediatr.Send(updateApplicantCommandResponseDto.Adapt<UpdateApplicantCommandRequest>());
            if (updateApplicant.Id == -1)
            {
                return new ServiceResponse<UpdateApplicantCommandResponse>(500, false, updateApplicant.ErrorMessage);
            }
            _uof.Commit();
            return new ServiceResponse<UpdateApplicantCommandResponse>(200, true, updateApplicant);
        }
    }
}
