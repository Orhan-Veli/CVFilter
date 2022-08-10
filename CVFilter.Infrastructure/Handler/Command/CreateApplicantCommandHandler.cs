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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CVFilter.Infrastructure.EntityRepository;
using CVFilter.Infrastructure.EntityRepository.Base;
using CVFilter.Domain.Entities;

namespace CVFilter.Infrastructure.Handler.Command
{
    public class CreateApplicantCommandHandler : ICommandRequestHandler<CreateApplicantCommandRequest, CreateApplicantCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<Applicant> _applicantRepo;
        public CreateApplicantCommandHandler(IConfiguration configuration,
        IEntityRepository<Applicant> applicantRepo)
        {
            _configuration = configuration;
            _applicantRepo = applicantRepo;
        }
        public async Task<CreateApplicantCommandResponse> Handle(CreateApplicantCommandRequest request, CancellationToken cancellationToken)
        {
                try
                {
                    var applicant = new Applicant
                    {
                        Matches = request.Matches,
                        Path = request.Path,
                        Name = request.Name,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        TotalExperience = request.TotalExperience 
                    };
                    await _applicantRepo.Create(applicant);
                    return new CreateApplicantCommandResponse();
                }
                catch(Exception ex)
                {
                    LogFile.Write(Errors.Error, ErrorMessages.ErrorCreateApplicant + ex.Message);
                    return new CreateApplicantCommandResponse { Id = -1, ErrorMessage = ex.Message };
                }
            
        }
    }
}
