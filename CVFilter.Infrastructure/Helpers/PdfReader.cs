using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CVFilter.Infrastructure.PdfHelper
{
    public static class PdfReader
    {
        public static string GetTextFromThePage(this string path)
        {
            var pageTextArray = new List<string>();
            using (var stream = File.OpenRead(path))
            {
                using (UglyToad.PdfPig.PdfDocument document = UglyToad.PdfPig.PdfDocument.Open(stream))
                {
                    var getPageCount = document.NumberOfPages;
                    for (int i = 1; i <= getPageCount; i++)
                    {
                        var page = document.GetPage(i); 
                        pageTextArray.Add(string.Join(" ", page.GetWords()));
                    }
                    return String.Concat(pageTextArray);
                }
            }            
        }
    }
}
