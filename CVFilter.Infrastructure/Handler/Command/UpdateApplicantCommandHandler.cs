using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Command.Request;
using CVFilter.Infrastructure.Command.Response;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CVFilter.Domain.Core.Constants;
using CVFilter.Domain.Cross_Cutting_Concerns;
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;

namespace CVFilter.Infrastructure.Handler.Command
{
    public class UpdateApplicantCommandHandler : ICommandRequestHandler<UpdateApplicantCommandRequest, UpdateApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<Applicant> _applicantRepo;
        public UpdateApplicantCommandHandler(IConfiguration configuration,IEntityRepository<Applicant> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<UpdateApplicantCommandResponse> Handle(UpdateApplicantCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    var updateResult = new Applicant
                    {
                        Name = request.Name,
                        Matches = request.Matches,
                        Path = request.Path,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        TotalExperience = request.TotalExperience,
                        IsActive = request.IsActive,
                        IsDeleted = request.IsDeleted,
                        UpdatedDate = request.UpdatedDate,
                        Id = request.Id
                    };
                    await _applicantRepo.Update(updateResult);
                    return new UpdateApplicantCommandResponse { Id = updateResult.Id };
                }
                catch (Exception ex)
                {
                    LogFile.Write(Errors.Error, ErrorMessages.ErrorUpdateApplicant + ex.Message);
                    return new UpdateApplicantCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            
        }
    }
}
