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
using CVFilter.Domain.Core.Constants;
using CVFilter.Domain.Cross_Cutting_Concerns;
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;

namespace CVFilter.Infrastructure.Handler.Command
{
    public class DeleteApplicantCommandHandler : ICommandRequestHandler<DeleteApplicantCommandRequest, DeleteApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<Applicant> _applicantRepo;
        public DeleteApplicantCommandHandler(IConfiguration configuration,
        IEntityRepository<Applicant> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }

        public async Task<DeleteApplicantCommandResponse> Handle(DeleteApplicantCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    var app = await _applicantRepo.Get(x=> x.Id == request.Id);
                    await _applicantRepo.Delete(app);
                    return new DeleteApplicantCommandResponse { Success = true };
                }
                catch(Exception ex)
                {
                    LogFile.Write(Errors.Error, ErrorMessages.ErrorDeleteApplicant + ex.Message);
                    return new DeleteApplicantCommandResponse { Success = false, ErrorMessage=ex.Message };
                }
            
        }
    }
}
