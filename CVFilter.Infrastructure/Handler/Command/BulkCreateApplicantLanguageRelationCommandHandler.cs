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
    public class BulkCreateApplicantLanguageRelationCommandHandler : ICommandRequestHandler<BulkCreateApplicantLanguageRelationCommandRequest, BulkCreateApplicantLanguageRelationCommandResponse>
    {
        private readonly IConfiguration _configuration;
        public BulkCreateApplicantLanguageRelationCommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<BulkCreateApplicantLanguageRelationCommandResponse> Handle(BulkCreateApplicantLanguageRelationCommandRequest request, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    string insertSql = string.Empty;
                    foreach (var item in request.CreateApplicantLanguageRelations)
                    {
                        var createApplicantQuery = @"INSERT INTO ApplicantLanguageRelations (ApplicantId,Langugage) VALUES ('" + item.ApplicantId + "','" + item.Langugage + "') ";
                        insertSql += createApplicantQuery;
                    }
                    var createResult = await connection.ExecuteAsync(insertSql);
                    return new BulkCreateApplicantLanguageRelationCommandResponse();
                }
                catch (Exception ex)
                {
                    return new BulkCreateApplicantLanguageRelationCommandResponse { ErrorMessage = ex.Message };
                }
            }
        }
    }
}
