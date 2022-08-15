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
using CVFilter.Domain.Cross_Cutting_Concerns;
using Mapster;
using CVFilter.Infrastructure.UnitOfWork;
using CVFilter.Infrastructure.UnitOfWork.Base;
using CVFilter.Domain.Core.Constants;

namespace CVFilter.Application.Concrete
{
    public class ApplicantService : IApplicantService
    {
        private readonly IMediator _mediatr;
        private readonly IUnitOfWork _uof;
        private readonly MemoryCache _cache;
        public ApplicantService(IMediator mediatr,IUnitOfWork uof, MemoryCache cache)
        {
            _mediatr = mediatr;
            _uof = uof;
            _cache = cache; 
        }
        public async Task<IServiceResponse<CreateApplicantCommandResponse>> CreateAsync(CreateApplicantCommandRequestDto createApplicantCommandRequestDto)
        {
            if (createApplicantCommandRequestDto == null || string.IsNullOrEmpty(createApplicantCommandRequestDto.Path) || string.IsNullOrEmpty(createApplicantCommandRequestDto.Matches))
            {
                return new ServiceResponse<CreateApplicantCommandResponse>(400,false,ErrorMessages.ErrorCreateApplicant);
            }

            var createApplicant = await _mediatr.Send(createApplicantCommandRequestDto.Adapt<CreateApplicantCommandRequest>());
            if (createApplicant.Id == -1)
            {
                return new ServiceResponse<CreateApplicantCommandResponse>(500, false, createApplicant.ErrorMessage);
            }
            _uof.Commit();
            _cache.DeleteCache();
            return new ServiceResponse<CreateApplicantCommandResponse>(201, true, new CreateApplicantCommandResponse { Id = createApplicant.Id });
        }

        public async Task<IServiceResponse<DeleteApplicantCommandResponse>> DeleteAsync(DeleteApplicantCommandRequestDto deleteApplicantCommandRequestDto)
        {
            if (deleteApplicantCommandRequestDto == null || deleteApplicantCommandRequestDto.Id == 0)
            {
                return new ServiceResponse<DeleteApplicantCommandResponse>(400, false, ErrorMessages.ErrorDeleteApplicant);
            }

            var deleteApplicant = await _mediatr.Send(deleteApplicantCommandRequestDto.Adapt<DeleteApplicantCommandRequest>());
            if (!deleteApplicant.Success)
            {
                return new ServiceResponse<DeleteApplicantCommandResponse>(500, false, deleteApplicant.ErrorMessage);
            }
            _uof.Commit();
            _cache.DeleteCache();
            return new ServiceResponse<DeleteApplicantCommandResponse>(204, deleteApplicant.Success);
        }

        public async Task<IServiceResponse<GetAllApplicantQueryResponse>> GetAllAsync(GetAllApplicantQueryRequestDto getAllApplicantQueryRequestDto)
        {
            var getCacheValue = _cache.GetApplicants();
            if (getCacheValue != null)
            {
                return new ServiceResponse<GetAllApplicantQueryResponse>(200, true, getCacheValue.Adapt<GetAllApplicantQueryResponse>());
            }

            var getAllApplicant = await _mediatr.Send(getAllApplicantQueryRequestDto.Adapt<GetAllApplicantQueryRequest>());
            if (!getAllApplicant.GetApplicantQueryResponses.Any() || !string.IsNullOrEmpty(getAllApplicant.Errors))
            {
                return new ServiceResponse<GetAllApplicantQueryResponse>(200, false, new GetAllApplicantQueryResponse(), getAllApplicant?.Errors);
            }
            return new ServiceResponse<GetAllApplicantQueryResponse>(200, true, getAllApplicant);
        }

        public async Task<IServiceResponse<GetApplicantQueryResponse>> GetAsync(GetApplicantQueryRequestDto getApplicantQueryRequestDto)
        {
            if (getApplicantQueryRequestDto == null || getApplicantQueryRequestDto.Id == 0)
            {
                return new ServiceResponse<GetApplicantQueryResponse>(400, false, ErrorMessages.ErrorGetApplicant);
            }

            var getApplicant = await _mediatr.Send(getApplicantQueryRequestDto.Adapt<GetApplicantQueryRequest>());
            if(getApplicant == null)
            {
                return new ServiceResponse<GetApplicantQueryResponse>(404, false, ErrorMessages.ErrorGetApplicant);
            }
            return new ServiceResponse<GetApplicantQueryResponse>(200, true, getApplicant);
        }

        public async Task<IServiceResponse<UpdateApplicantCommandResponse>> UpdateAsync(UpdateApplicantCommandRequestDto updateApplicantCommandResponseDto)
        {
            if (updateApplicantCommandResponseDto == null || updateApplicantCommandResponseDto.Id==0 || string.IsNullOrEmpty(updateApplicantCommandResponseDto.Matches) || string.IsNullOrEmpty(updateApplicantCommandResponseDto.Path))
            {
                return new ServiceResponse<UpdateApplicantCommandResponse>(400, false, ErrorMessages.ErrorUpdateApplicant);
            }

            var updateApplicant = await _mediatr.Send(updateApplicantCommandResponseDto.Adapt<UpdateApplicantCommandRequest>());
            if (updateApplicant.Id == -1)
            {
                return new ServiceResponse<UpdateApplicantCommandResponse>(500, false, updateApplicant.ErrorMessage);
            }
            _uof.Commit();
            _cache.DeleteCache();
            return new ServiceResponse<UpdateApplicantCommandResponse>(200, true, updateApplicant);
        }
    }
}
