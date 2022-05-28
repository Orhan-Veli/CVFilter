using CVFilter.Application.Abstract;
using CVFilter.Application.Dto;
using CVFilter.Domain.Core.ServiceResponse;
using CVFilter.Domain.Core.ServiceResponse.Base;
using CVFilter.Infrastructure.PdfHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CVFilter.Infrastructure.Command.Request;
using Mapster;

namespace CVFilter.Application.Concrete
{
    public class CVService : ICVService
    {
        private readonly IMediator _mediatr;
        public CVService(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task<IServiceResponse<List<int>>> CVWorkerAsync(CVWorkerRequestDto cVWorkerRequestDto)
        {
            if (cVWorkerRequestDto == null || string.IsNullOrEmpty(cVWorkerRequestDto.Path) || string.IsNullOrEmpty(cVWorkerRequestDto.Matches))
            {
                return new ServiceResponse<List<int>>(400, false, "CV Model is not valid"); 
            }

            var getMatches = cVWorkerRequestDto.Matches.Split(',');
            var getPageTexts = PdfReader.GetTextFromThePage(cVWorkerRequestDto.Path);
            var matcheds = GetMatchesCount(getMatches, getPageTexts);
            var name = String.Join(" ", getPageTexts[0].Split(" ").ToList().GetRange(2, getPageTexts[0].Split(" ").ToList().IndexOf("@")).ToArray());
            var createApplicant = new CreateApplicantCommandRequestDto
            {
                Name = name,
                Matches =String.Join(",", matcheds),
                Path = cVWorkerRequestDto.Path
            };
            var result = await _mediatr.Send(createApplicant.Adapt<CreateApplicantCommandRequest>());
            if(result.Id == -1)
            {
                return new ServiceResponse<List<int>>(500, false, "Applicant cannot be created");
            }

           return new ServiceResponse<List<int>>(201, true, new List<int> { result.Id });
        }
        private List<string> GetMatchesCount(string[] matches, List<string> textPage)
        {
            var matcheds = new List<string>();
            foreach (var page in textPage)
            {
                foreach (var key in matches)
                {
                    if (page.Contains(key))
                    {
                        matcheds.Add(key);
                    }
                }
            }
            return matcheds;
        }
    }
}
