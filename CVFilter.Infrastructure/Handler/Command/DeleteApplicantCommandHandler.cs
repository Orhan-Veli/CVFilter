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
    public class DeleteApplicantCommandHandler : ICommandRequestHandler<DeleteApplicantCommandRequest, DeleteApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public DeleteApplicantCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DeleteApplicantCommandResponse> Handle(DeleteApplicantCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var deleteResult = await connection.ExecuteAsync(Queries.DeleteApplicantQuery, new { request.Id });
                    return new DeleteApplicantCommandResponse { Success = true };
                }
                catch(Exception ex)
                {
                    return new DeleteApplicantCommandResponse { Success = false, ErrorMessage=ex.Message };
                }
            }
        }
    }
}
