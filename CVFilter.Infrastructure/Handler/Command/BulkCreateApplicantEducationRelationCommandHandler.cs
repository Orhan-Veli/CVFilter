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
    public class BulkCreateApplicantEducationRelationCommandHandler : ICommandRequestHandler<BulkCreateApplicantEducationRelationCommandRequest, BulkCreateApplicantEducationRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<ApplicantEducationRelation> _applicantRepo;
        public BulkCreateApplicantEducationRelationCommandHandler(IConfiguration configuration,IEntityRepository<ApplicantEducationRelation> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<BulkCreateApplicantEducationRelationCommandResponse> Handle(BulkCreateApplicantEducationRelationCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    foreach (var item in request.CreateApplicantEducationRelations)
                    {
                        var applicantEd = new ApplicantEducationRelation
                        {
                            ApplicantId = item.ApplicantId, 
                            SchoolName = item.SchoolName
                        };
                        await _applicantRepo.Create(applicantEd).ConfigureAwait(false);
                    }
                    return new BulkCreateApplicantEducationRelationCommandResponse();
                }
                catch (Exception ex)
                {
                    LogFile.Write(Errors.Error, ErrorMessages.ErrorBulkCreateApplicantEducationRelation + ex.Message);
                return new BulkCreateApplicantEducationRelationCommandResponse { ErrorMessage = ex.Message };
                }
            
        }
    }
}
