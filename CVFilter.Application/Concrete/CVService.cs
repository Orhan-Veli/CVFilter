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
using System.IO;

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
            var applicantDtos = new List<CreateApplicantCommandRequestDto>();
            var getMatches = cVWorkerRequestDto.Matches.Split(',');
            var getPdfFiles = Directory.GetFiles(cVWorkerRequestDto.Path, "*.pdf").ToList();
            foreach (var pdfFile in getPdfFiles)
            {
                var getPageTexts = PdfReader.GetTextFromThePage(pdfFile);
                var matcheds = GetMatchesCount(getMatches, getPageTexts);
                if (matcheds.Any())
                {
                    var name = GetNameFromPage(getPageTexts);
                    var createApplicant = new CreateApplicantCommandRequestDto
                    {
                        User = name,
                        Matches = String.Join(",", matcheds),
                        Path = cVWorkerRequestDto.Path
                    };
                    applicantDtos.Add(createApplicant);
                }
            }
            
           
            //var result = await _mediatr.Send(createApplicant.Adapt<CreateApplicantCommandRequest>());
            //if(result.Id == -1)
            //{
            //    return new ServiceResponse<List<int>>(500, false, "Applicant cannot be created");
            //}

           //return new ServiceResponse<List<int>>(201, true, new List<int> { result.Id });
           return new ServiceResponse<List<int>>(201, true, new List<int> { -1 });
        }

        private string GetNameFromPage(List<string> texts)
        {
            var name = string.Empty;
            foreach (var text in texts[0].Split(' ').Skip(2))
            {
                if (text.Contains("@")) break;
                name += text;
            }
            return name;
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
