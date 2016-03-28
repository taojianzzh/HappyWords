using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyWords.Web.Models
{
    public class UpdateWordRequest
    {
        public string Chinese { get; set; }
        public string UsPron { get; set; }
        public string UkPron { get; set; }

        public Data.Models.Word ConvertToWord(string spelling)
        {
            return new Data.Models.Word(spelling, Chinese, UsPron, UkPron);
        }
    }
}