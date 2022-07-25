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
using CVFilter.Domain.Core.SqlQueries;
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;

namespace CVFilter.Infrastructure.Handler.Command
{
    public class CreateApplicantLanguageRelationCommandHandler : ICommandRequestHandler<CreateApplicantLanguageRelationCommandRequest, CreateApplicantLanguageRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<ApplicantLanguageRelation> _applicantRepo;
        public CreateApplicantLanguageRelationCommandHandler(IConfiguration configuration,IEntityRepository<ApplicantLanguageRelation> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<CreateApplicantLanguageRelationCommandResponse> Handle(CreateApplicantLanguageRelationCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    var createResult = new ApplicantLanguageRelation
                    {
                        ApplicantId =request.ApplicantId,
                        Language = request.Language,
                    };
                    await _applicantRepo.Create(createResult);
                    return new CreateApplicantLanguageRelationCommandResponse();
                }
                catch (Exception ex)
                {
                    return new CreateApplicantLanguageRelationCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            
        }
    }
}
