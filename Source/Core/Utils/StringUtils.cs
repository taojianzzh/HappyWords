using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Core.Utils
{
    public static class StringUtils
    {
        public static string GetPart(string s, string startSymbol, string endSymbol)
        {
            int startIndex = s.IndexOf(startSymbol);
            if (startIndex >= 0)
            {
                int endIndex = s.IndexOf(endSymbol, startIndex + startSymbol.Length);
                if (endIndex >= 0)
                {
                    return s.Substring(startIndex + startSymbol.Length, endIndex - startIndex - startSymbol.Length);
                }
            }

            return string.Empty;
        }

        public static string GetPart(string s, char startSymbol, char endSymbol)
        {
            int startIndex = s.IndexOf(startSymbol);
            if (startIndex >= 0)
            {
                int endIndex = s.IndexOf(endSymbol, startIndex + 1);
                if (endIndex >= 0)
                {
                    return s.Substring(startIndex + 1, endIndex - startIndex - 1);
                }
            }

            return string.Empty;
        }
    }
}
