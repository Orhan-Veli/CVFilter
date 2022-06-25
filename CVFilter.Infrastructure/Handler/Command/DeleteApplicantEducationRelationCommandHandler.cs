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
    public class DeleteApplicantEducationRelationCommandHandler : ICommandRequestHandler<DeleteApplicantEducationRelationCommandRequest, DeleteApplicantEducationRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public DeleteApplicantEducationRelationCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DeleteApplicantEducationRelationCommandResponse> Handle(DeleteApplicantEducationRelationCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var deleteResult = await connection.ExecuteAsync(Queries.DeleteApplicantEducationRelationQuery, new { request.Id });
                    return new DeleteApplicantEducationRelationCommandResponse { Success = true };
                }
                catch (Exception ex)
                {
                    return new DeleteApplicantEducationRelationCommandResponse { Success = false, ErrorMessage = ex.Message };
                }
            }
        }
    }
}
