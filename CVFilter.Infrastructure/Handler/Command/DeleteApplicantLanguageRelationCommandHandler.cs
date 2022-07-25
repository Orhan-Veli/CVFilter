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
    public class DeleteApplicantLanguageRelationCommandHandler : ICommandRequestHandler<DeleteApplicantLanguageRelationCommandRequest, DeleteApplicantLanguageRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<ApplicantLanguageRelation> _applicantRepo;
        public DeleteApplicantLanguageRelationCommandHandler(IConfiguration configuration,IEntityRepository<ApplicantLanguageRelation> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<DeleteApplicantLanguageRelationCommandResponse> Handle(DeleteApplicantLanguageRelationCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    var app = await _applicantRepo.Get(x=> x.Id == request.Id);
                    await _applicantRepo.Delete(app);
                    return new DeleteApplicantLanguageRelationCommandResponse { Success = true };
                }
                catch (Exception ex)
                {
                    return new DeleteApplicantLanguageRelationCommandResponse { Success = false, ErrorMessage = ex.Message };
                }
            
        }
    }
}
