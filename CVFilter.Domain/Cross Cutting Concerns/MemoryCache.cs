using System;
using System.Collections.Generic;
using System.Text;
using CVFilter.Domain.Core.Constants;
using CVFilter.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CVFilter.Domain.Cross_Cutting_Concerns
{
    public class MemoryCache
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void CreateCache(List<Applicant> applicants)
        {
            _memoryCache.CreateEntry(JsonSerializer.Serialize(applicants));
        }

        public List<Applicant> GetApplicants()
        {
            return JsonSerializer.Deserialize<List<Applicant>>(CacheKeys.applicantMemcache);
        }

        public void DeleteCache()
        {
            _memoryCache.Remove(CacheKeys.applicantMemcache);
        }
    }
}
