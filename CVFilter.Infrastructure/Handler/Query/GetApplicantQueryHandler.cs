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
            var result = await _applicantRepo.Get(x => x.Id == request.Id && !x.IsDeleted && x.IsActive);
            return new GetApplicantQueryResponse { Id= result.Id, Matches=result.Matches, Path=result.Path, User= result.Name};
        }
    }
}
