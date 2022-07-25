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
using CVFilter.Domain.Core.Extensions;
using System.Text.RegularExpressions;
using CVFilter.Infrastructure.UnitOfWork;
using CVFilter.Infrastructure.UnitOfWork.Base;
using CVFilter.Domain.Core.Enums;

namespace CVFilter.Application.Concrete
{
    public class CVService : ICVService
    {
        private readonly IMediator _mediatr;
        private readonly IUnitOfWork _uof;
        public string[] splittedText;
        public CVService(IMediator mediatr,IUnitOfWork uof)
        {
            _mediatr = mediatr;
            _uof = uof;
            splittedText = new string[] { };
        }

        public async Task<IServiceResponse<string>> CVWorkerAsync(CVWorkerRequestDto cVWorkerRequestDto)
        {
            try
            {
                if (cVWorkerRequestDto == null || string.IsNullOrEmpty(cVWorkerRequestDto.Path) || string.IsNullOrEmpty(cVWorkerRequestDto.RequiredMatches) || string.IsNullOrEmpty(cVWorkerRequestDto.LanguageMatches) || string.IsNullOrEmpty(cVWorkerRequestDto.EducationMatches))
                {
                    return new ServiceResponse<string>(400, false, "CV Model is not valid");
                }
                var getPdfFiles = Directory.GetFiles(cVWorkerRequestDto.Path, "*.pdf").ToList();
                foreach (var pdfFile in getPdfFiles)
                {
                    var createApplicant = new CreateApplicantCommandRequest();
                    var addEducationRelation = new BulkCreateApplicantEducationRelationCommandRequest();
                    var addLanguageRelation = new BulkCreateApplicantLanguageRelationCommandRequest();
                    var getPageTexts = PdfReader.GetTextFromThePage(pdfFile).ToLower();
                    var isTextInEnglish = getPageTexts.Split(' ').First() == "contact";
                    splittedText = getPageTexts.Split(' ');
                    var replacedText = getPageTexts.Replace(',', ' ').Replace('-', ' ').Replace('.', ' ').ToLower();

                    createApplicant.Name = GetApplicantName(isTextInEnglish ? splittedText.Skip(1).Take(10).ToList() : splittedText.Skip(2).Take(10).ToList());
                    createApplicant.Matches = String.Concat(GetMatchesList(cVWorkerRequestDto.RequiredMatches.Split(','), replacedText, FilterEnum.Required, isTextInEnglish)?.ToArray());

                    if (string.IsNullOrEmpty(createApplicant.Matches))
                    {
                        continue;
                    }

                    createApplicant.TotalExperience = IntExtension.GetExperience(
                    StringExtension.GetBetweenTwoString(splittedText.First(),
                        getPageTexts.Contains("education") ? "education" : "eğitim", getPageTexts));
                    createApplicant.Path = pdfFile;
                    createApplicant.Email = splittedText.Where(x => x.Contains("@")).FirstOrDefault();
                    createApplicant.PhoneNumber = splittedText.Where(x => x.Length > 5 && x.All(char
                        .IsNumber)).FirstOrDefault();

                    var createdApplicantResult = await _mediatr.Send(createApplicant);
                    if (!String.IsNullOrEmpty(createdApplicantResult.ErrorMessage))
                    {
                        await _mediatr.Send(new CreateLogCommandRequest
                        {
                            ErrorMessage = createdApplicantResult.ErrorMessage
                        });
                        return new ServiceResponse<string>(500, false, "ApplicantCreate Error");
                    }

                    GetMatchesList(cVWorkerRequestDto.EducationMatches.Split(','), replacedText, FilterEnum.Education, isTextInEnglish)?.ForEach(x =>
                    {
                        var createApplicantEducationRelationCommandRequest = new CreateApplicantEducationRelationCommandRequest
                        {
                            ApplicantId = createdApplicantResult.Id,
                            SchoolName = x
                        };
                        addEducationRelation.CreateApplicantEducationRelations.Add(createApplicantEducationRelationCommandRequest);
                    });
                    GetMatchesList(cVWorkerRequestDto.LanguageMatches.Split(','), replacedText, FilterEnum.Langugage, isTextInEnglish)?.ForEach(x =>
                    {
                        var createApplicantEducationRelationCommandRequest = new CreateApplicantLanguageRelationCommandRequest
                        {
                            ApplicantId = createdApplicantResult.Id,
                            Langugage = x
                        };
                        addLanguageRelation.CreateApplicantLanguageRelations.Add(createApplicantEducationRelationCommandRequest);
                    });

                    if (addEducationRelation.CreateApplicantEducationRelations.Any())
                    {
                        await _mediatr.Send(addEducationRelation);
                    }

                    if (addLanguageRelation.CreateApplicantLanguageRelations.Any())
                    {
                        await _mediatr.Send(addLanguageRelation);
                    }
                }
                _uof.Commit();
                return new ServiceResponse<string>(201, true);
            }
            catch (Exception x)
            {
                await _mediatr.Send(new CreateLogCommandRequest
                {
                    ErrorMessage = x.Message
                });
                return new ServiceResponse<string>(500, false, "There is an error" + x.Message);
            }

        }

        private string GetApplicantName(List<string> splittedText)
        {
            var name = string.Empty;
            foreach (var textItem in splittedText)
            {
                if (textItem.Contains("www") || textItem.All(char.IsNumber) || textItem.StartsWith("+") || textItem.Contains("@"))
                {
                    break;
                }
                name += textItem + " ";
            }
            return name;
        }

        private List<string> GetMatchesList(string[] matches, string textPage, FilterEnum filterEnum, bool isEnglish = true)
        {
            var matcheds = new List<string>();
            var education = isEnglish ? "education" : "eğitim";
            if (filterEnum == FilterEnum.Required)
            {
                foreach (var key in matches)
                {
                    if (StringExtension.GetBetweenTwoString(textPage.Split(' ').First(), "", textPage).Contains(key))
                    {
                        matcheds.Add(key);
                    }
                }
            }
            else
            {
                var textPageControl = textPage.Split(' ').ToList();
                if (textPageControl.Count(x => x == education) > 1)
                {
                    var tempTextPage = textPage.Split(' ').ToList();
                    for (int i = 0; i < textPageControl.Count(x => x == education) - 1; i++)
                    {
                        for (int j = 0; j < tempTextPage.Count; j++)
                        {
                            if (tempTextPage[i] == education)
                            {
                                tempTextPage[i] = "";
                                break; ;
                            }
                        }
                    }

                    textPage = string.Concat(tempTextPage);
                }

                foreach (var key in matches)
                {
                    if (StringExtension.GetBetweenTwoString(education, "", textPage).Contains(key))
                    {
                        matcheds.Add(key);
                    }
                }
            }
            return matcheds;
        }
    }
}
