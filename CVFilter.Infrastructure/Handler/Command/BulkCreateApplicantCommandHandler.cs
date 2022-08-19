
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
    public class BulkCreateApplicantCommandHandler : ICommandRequestHandler<BulkCreateApplicantCommandRequest, BulkCreateApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<Applicant> _applicantRepo;
        public BulkCreateApplicantCommandHandler(IConfiguration configuration,IEntityRepository<Applicant> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<BulkCreateApplicantCommandResponse> Handle(BulkCreateApplicantCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    foreach (var item in request.CreateApplicants)
                    {
                        var applicant = new Applicant
                        {
                            Matches = item.Matches,
                            Path = item.Path,
                            Name = item.Name,
                            Email = item.Email,
                            PhoneNumber = item.PhoneNumber,
                            TotalExperience = item.TotalExperience 
                        };
                        await _applicantRepo.Create(applicant).ConfigureAwait(false);
                    }
                    return new BulkCreateApplicantCommandResponse();
                }
                catch (Exception ex)
                {
                    LogFile.Write(Errors.Error,ErrorMessages.ErrorBulkCreateApplicant + ex.Message);
                    return new BulkCreateApplicantCommandResponse { ErrorMessage = ex.Message };
                }
        }
    }
}
