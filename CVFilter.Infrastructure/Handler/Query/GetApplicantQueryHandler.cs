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
    public class GetApplicantQueryHandler : IQueryRequestHandler<GetApplicantQueryRequest, GetApplicantQueryResponse>
    {
        private readonly IConfiguration _configuration;
        public GetApplicantQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GetApplicantQueryResponse> Handle(GetApplicantQueryRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var getApplicant = @"SELECT * FROM Applicants WHERE ID = @Id";
                var result = await connection.QueryAsync<GetApplicantQueryResponse>(getApplicant, new { request.Id });
                return result.FirstOrDefault();
            }
        }
    }
}
