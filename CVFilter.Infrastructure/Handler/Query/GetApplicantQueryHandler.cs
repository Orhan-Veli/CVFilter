using System.Net.Mime;
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
    public class GetApplicantQueryHandler : IQueryRequestHandler<GetApplicantQueryRequest, GetApplicantQueryResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<Applicant> _applicantRepo;
        public GetApplicantQueryHandler(IConfiguration configuration, IEntityRepository<Applicant> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }

        public async Task<GetApplicantQueryResponse> Handle(GetApplicantQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var includeFilter = new List<Expression<Func<Applicant, object>>>();
                includeFilter.Add(x => x.ApplicantLanguagesRelations);
                includeFilter.Add(x => x.ApplicantEducationRelations);
                var result = await _applicantRepo.Get(x => x.Id == request.Id && !x.IsDeleted && x.IsActive, includeFilter);
                return new GetApplicantQueryResponse { Id = result.Id, Matches = result.Matches, Path = result.Path, User = result.Name, ApplicantEducationRelations = result.ApplicantEducationRelations.Select(x => new ApplicantEducationRelation { ApplicantId = x.ApplicantId, SchoolName = x.SchoolName, Id = x.Id }).ToList(), ApplicantLanguageRelations = result.ApplicantLanguagesRelations.ToList().Select(x => new ApplicantLanguageRelation { ApplicantId = x.ApplicantId, Langugage = x.Langugage, Id = x.Id }).ToList() };
            }
            catch (Exception ex)
            {
                LogFile.Write(Errors.Error, ErrorMessages.ErrorGetApplicant + ex.Message);
                return new GetApplicantQueryResponse { Error = ex.Message };
            }
        }
    }
}
