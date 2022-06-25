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

namespace CVFilter.Infrastructure.Handler.Command
{
    public class CreateApplicantLanguageRelationCommandHandler : ICommandRequestHandler<CreateApplicantLanguageRelationCommandRequest, CreateApplicantLanguageRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateApplicantLanguageRelationCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CreateApplicantLanguageRelationCommandResponse> Handle(CreateApplicantLanguageRelationCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var createResult = await connection.QuerySingleAsync<int>(Queries.CreateApplicantLanguageRelationQuery, new
                    {
                        request.ApplicantId,
                        request.Langugage,
                    });
                    return new CreateApplicantLanguageRelationCommandResponse { Id = createResult };
                }
                catch (Exception ex)
                {
                    return new CreateApplicantLanguageRelationCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            }
        }
    }
}
