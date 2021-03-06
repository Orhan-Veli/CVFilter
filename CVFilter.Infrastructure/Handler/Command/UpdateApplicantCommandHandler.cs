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
    public class UpdateApplicantCommandHandler : ICommandRequestHandler<UpdateApplicantCommandRequest, UpdateApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public UpdateApplicantCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<UpdateApplicantCommandResponse> Handle(UpdateApplicantCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var updateResult = await connection.ExecuteAsync(Queries.UpdateApplicantQuery, new
                    {
                        request.Name,
                        request.Matches,
                        request.Path,
                        request.Email,
                        request.PhoneNumber,
                        request.TotalExperience,
                        request.IsActive,
                        request.IsDeleted,
                        request.UpdatedDate,
                        request.Id
                    });
                    return new UpdateApplicantCommandResponse { Id = updateResult };
                }
                catch (Exception ex)
                {
                    return new UpdateApplicantCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            }
        }
    }
}
