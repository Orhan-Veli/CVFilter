using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CVFilter.Domain.Core.Extensions
{
    public class IntExtension
    {
        public static int GetExperience(string text)
        {
            var totalExperience = 0;
            var tempMonthExperience = 0;
            var regExp = new Regex(@"\(([^)]*)\)");
            var arrayMatches = regExp.Matches(text).Select(x=>x.Value).ToList();
            if (!arrayMatches.Any()) return 0;

            foreach (var exp in arrayMatches)
            {
                var splitVal = exp.Replace("(", "").Replace(")", "").Split(' ');
                if ((splitVal.Contains("months") || splitVal.Contains("ay")) && (splitVal.Contains("yıl") || splitVal.Contains("years")))
                {
                    totalExperience += Convert.ToInt32(splitVal[0]);
                    tempMonthExperience += Convert.ToInt32(splitVal[2]);
                }
                else if ((splitVal.Contains("months") || splitVal.Contains("ay")) && !(splitVal.Contains("yıl") || splitVal.Contains("years")))
                {
                    tempMonthExperience += Convert.ToInt32(splitVal[0]);
                }
                else if (!(splitVal.Contains("months") || splitVal.Contains("ay")) && (splitVal.Contains("yıl") || splitVal.Contains("years")))
                {
                    totalExperience += Convert.ToInt32(splitVal[0]);
                }
            }

            var getTotalYearsFromMonthCount = tempMonthExperience >= 12 ? 1 : tempMonthExperience % 12;
            return totalExperience + getTotalYearsFromMonthCount;
        }
    }
}
