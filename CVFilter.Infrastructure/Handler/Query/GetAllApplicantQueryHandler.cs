using System.Security.Cryptography.X509Certificates;
using CVFilter.Domain.Core.Interfaces;
using CVFilter.Infrastructure.Query.Request;
using CVFilter.Infrastructure.Query.Response;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;
using CVFilter.Domain.Cross_Cutting_Concerns;
using CVFilter.Domain.Core.Constants;
using System.Linq.Expressions;

namespace CVFilter.Infrastructure.Handler.Query
{
    public class GetAllApplicantQueryHandler : IQueryRequestHandler<GetAllApplicantQueryRequest, GetAllApplicantQueryResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<Applicant> _applicantRepo;
        public GetAllApplicantQueryHandler(IConfiguration configuration,
        IEntityRepository<Applicant> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<GetAllApplicantQueryResponse> Handle(GetAllApplicantQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var expressions = new List<Expression<Func<Applicant, object>>>();
                expressions.Add(x => x.ApplicantLanguagesRelations);
                expressions.Add(x => x.ApplicantEducationRelations);
                
                var getAllApplicant = await _applicantRepo.GetAllQueryable(x => x.IsActive && !x.IsDeleted, expressions).ConfigureAwait(false);
                var getAllApplicantDto = new GetAllApplicantQueryResponse
                {
                    Errors = null,
                    GetApplicantQueryResponses = getAllApplicant.Select(x => new GetApplicantQueryResponse
                    {
                        Id = x.Id,
                        Matches = x.Matches,
                        Path = x.Path,
                        User = x.Name,
                        ApplicantLanguageRelations = x.ApplicantLanguagesRelations.Select(x => new ApplicantLanguageRelation { ApplicantId = x.ApplicantId, Langugage = x.Langugage, Id = x.Id }).ToList(),
                        ApplicantEducationRelations = x.ApplicantEducationRelations.Select(x => new ApplicantEducationRelation { ApplicantId = x.ApplicantId, SchoolName = x.SchoolName, Id = x.Id }).ToList()
                    }).ToList()
                };
                return getAllApplicantDto;
            }
            catch (Exception ex)
            {
                LogFile.Write(Errors.Error, ErrorMessages.ErrorGetAllApplicant + ex.Message);
                return new GetAllApplicantQueryResponse { Errors = ex.Message, GetApplicantQueryResponses = new List<GetApplicantQueryResponse>() };
            }            
        }
    }
}
