
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
    public class BulkCreateApplicantCommandHandler : ICommandRequestHandler<BulkCreateApplicantCommandRequest, BulkCreateApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public BulkCreateApplicantCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<BulkCreateApplicantCommandResponse> Handle(BulkCreateApplicantCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    string insertSql = string.Empty;
                    foreach (var item in request.CreateApplicants)
                    {
                        var isActive = item.IsActive == true ? 1 : 0;
                        var isDeleted= item.IsDeleted == true ? 1 : 0;
                        var createApplicantQuery = @"INSERT INTO Applicants ([Name],Matches,Path,PhoneNumber,Email,IsActive,IsDeleted,CreatedDate,UpdatedDate) VALUES ('" + item.Name + "','" + item.Matches + "','" + item.Path + "','" + item.PhoneNumber + "','" + item.Email + "'," + isActive + ","+ isDeleted + ",'"+item.CreatedDate+"','"+item.UpdatedDate+ "') ";
                        insertSql += createApplicantQuery;
                    }
                    var createResult = await connection.ExecuteAsync(insertSql);
                    return new BulkCreateApplicantCommandResponse();
                }
                catch (Exception ex)
                {
                    return new BulkCreateApplicantCommandResponse { ErrorMessage = ex.Message };
                }
            }
        }
    }
}
