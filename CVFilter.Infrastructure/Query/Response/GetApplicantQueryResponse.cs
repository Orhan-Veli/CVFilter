using CVFilter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Infrastructure.Query.Response
{
    public class GetApplicantQueryResponse
    {
        public GetApplicantQueryResponse()
        {
            ApplicantEducationRelations = new List<ApplicantEducationRelation>();
            ApplicantLanguageRelations = new List<ApplicantLanguageRelation>();
        }

        public int Id { get; set; }
        public string Matches { get; set; }
        public string Path { get; set; }
        public string User { get; set; }

        public List<ApplicantEducationRelation> ApplicantEducationRelations { get; set; }
        public List<ApplicantLanguageRelation> ApplicantLanguageRelations { get; set; }

        public string Error { get; set; }
    }
}
