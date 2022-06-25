using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.Extensions
{
    public static class StringExtension
    {
        public static string GetBetweenTwoString(string startString, string endString, string fullText)
        {
            if(!string.IsNullOrEmpty(endString))
                return fullText.Substring(fullText.IndexOf(startString),fullText.IndexOf(endString) - fullText.IndexOf(startString));
            return fullText.Substring(fullText.IndexOf(startString));
        }
    }
}
