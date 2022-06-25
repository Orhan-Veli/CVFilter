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
    public class BulkCreateApplicantEducationRelationCommandHandler : ICommandRequestHandler<BulkCreateApplicantEducationRelationCommandRequest, BulkCreateApplicantEducationRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public BulkCreateApplicantEducationRelationCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<BulkCreateApplicantEducationRelationCommandResponse> Handle(BulkCreateApplicantEducationRelationCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    string insertSql = string.Empty;
                    foreach (var item in request.CreateApplicantEducationRelations)
                    {
                        var createApplicantQuery = @"INSERT INTO ApplicantEducationRelations (ApplicantId,SchoolName) VALUES ('" + item.ApplicantId + "','" + item.SchoolName + "') ";
                        insertSql += createApplicantQuery;
                    }
                    var createResult = await connection.ExecuteAsync(insertSql);
                    return new BulkCreateApplicantEducationRelationCommandResponse();
                }
                catch (Exception ex)
                {
                    return new BulkCreateApplicantEducationRelationCommandResponse { ErrorMessage = ex.Message };
                }
            }
        }
    }
}
