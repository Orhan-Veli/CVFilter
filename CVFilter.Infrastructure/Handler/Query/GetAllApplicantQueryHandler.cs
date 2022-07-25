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
            var getAllApplicant = await _applicantRepo.GetAll(x=> x.IsActive && !x.IsDeleted);
            var getAllApplicantDto = new GetAllApplicantQueryResponse();
            foreach (var item in getAllApplicant)
            {
                var applicant = new GetApplicantQueryResponse
                {
                    Id = item.Id,
                    Matches = item.Matches,
                    Path = item.Path,
                    User = item.Name
                };
                getAllApplicantDto.GetApplicantQueryResponses.Add(applicant);
            }
            return getAllApplicantDto;
        }
    }
}
