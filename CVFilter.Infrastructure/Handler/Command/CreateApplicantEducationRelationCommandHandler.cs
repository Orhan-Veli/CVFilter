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
    public class CreateApplicantEducationRelationCommandHandler : ICommandRequestHandler<CreateApplicantEducationRelationCommandRequest, CreateApplicantEducationRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<ApplicantEducationRelation> _applicantRepo;
        public CreateApplicantEducationRelationCommandHandler(IConfiguration configuration,
        IEntityRepository<ApplicantEducationRelation> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<CreateApplicantEducationRelationCommandResponse> Handle(CreateApplicantEducationRelationCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    var createResult = new ApplicantEducationRelation
                    {
                        ApplicantId = request.ApplicantId,
                        SchoolName= request.SchoolName
                    };
                    await _applicantRepo.Create(createResult);
                    return new CreateApplicantEducationRelationCommandResponse();
                }
                catch (Exception ex)
                {
                    LogFile.Write(Errors.Error, ErrorMessages.ErrorCreateApplicantEducationRelation + ex.Message);
                    return new CreateApplicantEducationRelationCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            
        }
    }
}
