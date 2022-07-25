using System.Net.Mime;
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
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;

namespace CVFilter.Infrastructure.Handler.Command
{
    public class BulkCreateApplicantLanguageRelationCommandHandler : ICommandRequestHandler<BulkCreateApplicantLanguageRelationCommandRequest, BulkCreateApplicantLanguageRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<ApplicantLanguageRelation> _applicantRepo;
        public BulkCreateApplicantLanguageRelationCommandHandler(IConfiguration configuration,
        IEntityRepository<ApplicantLanguageRelation> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<BulkCreateApplicantLanguageRelationCommandResponse> Handle(BulkCreateApplicantLanguageRelationCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    foreach (var item in request.CreateApplicantLanguageRelations)
                    {
                        var applicantLan = new ApplicantLanguageRelation
                        {
                            ApplicantId = item.ApplicantId,
                            Language = item.Language
                        };
                        await _applicantRepo.Create(applicantLan);
                    }
                    return new BulkCreateApplicantLanguageRelationCommandResponse();
                }
                catch (Exception ex)
                {
                    return new BulkCreateApplicantLanguageRelationCommandResponse { ErrorMessage = ex.Message };
                }
            
        }
    }
}
