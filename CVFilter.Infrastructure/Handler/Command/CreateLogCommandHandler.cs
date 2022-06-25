using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CVFilter.Domain.Core.Interfaces;
using CVFilter.Domain.Core.SqlQueries;
using CVFilter.Infrastructure.Command.Request;
using CVFilter.Infrastructure.Command.Response;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace CVFilter.Infrastructure.Handler.Command
{
    public class CreateLogCommandHandler : ICommandRequestHandler<CreateLogCommandRequest, CreateLogCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateLogCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CreateLogCommandResponse> Handle(CreateLogCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var createResult = await connection.QuerySingleAsync<int>(Queries.CreateLogQuery, new
                    {
                        request.ErrorMessage,
                        request.IsActive,
                        request.IsDeleted,
                        request.CreatedDate,
                        request.UpdatedDate,
                    });
                    return new CreateLogCommandResponse { Id = createResult };
                }
                catch (Exception ex)
                {
                    return new CreateLogCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            }
        }
    }
}
