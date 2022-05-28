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

namespace CVFilter.Infrastructure.Handler.Query
{
    public class GetAllApplicantQueryHandler : IQueryRequestHandler<GetAllApplicantQueryRequest, GetAllApplicantQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetAllApplicantQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<GetAllApplicantQueryResponse> Handle(GetAllApplicantQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var getAllApplicant = @"SELECT * FROM Applicants WHERE [User] = @User";
                var result = await connection.QueryAsync<GetApplicantQueryResponse>(getAllApplicant, new { request.User});
                return new GetAllApplicantQueryResponse { GetApplicantQueryResponses = result.ToList() };
            }
        }
    }
}
