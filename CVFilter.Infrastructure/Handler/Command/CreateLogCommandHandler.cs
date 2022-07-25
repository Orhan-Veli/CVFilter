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
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;

namespace CVFilter.Infrastructure.Handler.Command
{
    public class CreateLogCommandHandler : ICommandRequestHandler<CreateLogCommandRequest, CreateLogCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<Log> _logRepo;
        public CreateLogCommandHandler(IConfiguration configuration,IEntityRepository<Log> logRepo)
        {
            _configuration = configuration;
            _logRepo = logRepo;
        }
        public async Task<CreateLogCommandResponse> Handle(CreateLogCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    var createResult = new Log
                    {
                        ErrorMessage = request.ErrorMessage,
                        IsActive = request.IsActive,
                        IsDeleted = request.IsDeleted,
                        CreatedDate = request.CreatedDate,
                        UpdatedDate = request.UpdatedDate,
                    };
                    await _logRepo.Create(createResult);
                    return new CreateLogCommandResponse();
                }
                catch (Exception ex)
                {
                    return new CreateLogCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            
        }
    }
}
