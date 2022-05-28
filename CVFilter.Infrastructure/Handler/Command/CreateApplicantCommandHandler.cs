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

namespace CVFilter.Infrastructure.Handler.Command
{
    public class CreateApplicantCommandHandler : ICommandRequestHandler<CreateApplicantCommandRequest, CreateApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public CreateApplicantCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CreateApplicantCommandResponse> Handle(CreateApplicantCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var createApplicantQuery = @"INSERT INTO Applicants ([Name],Matches,Path,IsActive,IsDeleted,CreatedDate,UpdatedDate,[User]) VALUES (@Name,@Matches,@Path,@IsActive,@IsDeleted,@CreatedDate,@UpdatedDate,@User)";

                    var createResult = await connection.ExecuteAsync(createApplicantQuery, new
                    {
                        request.Name,
                        request.Matches,
                        request.Path,
                        request.IsActive,
                        request.IsDeleted,
                        request.CreatedDate,
                        request.UpdatedDate,
                        request.User
                    });
                    return new CreateApplicantCommandResponse { Id = createResult };
                }
                catch(Exception ex)
                {
                    return new CreateApplicantCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            }
        }
    }
}
