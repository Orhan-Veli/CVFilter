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
    public class CreateApplicantEducationRelationCommandHandler : ICommandRequestHandler<CreateApplicantEducationRelationCommandRequest, CreateApplicantEducationRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateApplicantEducationRelationCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CreateApplicantEducationRelationCommandResponse> Handle(CreateApplicantEducationRelationCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var createResult = await connection.QuerySingleAsync<int>(Queries.CreateApplicantEducationRelationQuery, new
                    {
                        request.ApplicantId,
                        request.SchoolName,
                    });
                    return new CreateApplicantEducationRelationCommandResponse { Id = createResult };
                }
                catch (Exception ex)
                {
                    return new CreateApplicantEducationRelationCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            }
        }
    }
}
