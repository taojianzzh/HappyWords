using HappyWords.Core.Interfaces;
using HappyWords.Core.Models;
using HappyWords.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Core.Services
{
    public class BingDictService : IBingDictService
    {
        private const string URL_FORMAT = "http://cn.bing.com/dict/?q={0}";

        public BingDictWord Get(string spelling)
        {
            var url = string.Format(URL_FORMAT, spelling);
            var response = WebUtils.Get(url);
            var word = _ParseWord(response);
            return word;
        }

        private static BingDictWord _ParseWord(string response)
        {
            var word = new BingDictWord();

            //US Pronounce
            var usPrPart = WebUtility.HtmlDecode(StringUtils.GetPart(response, "<div class=\"hd_prUS\">", "</div>"));
            var usPr = StringUtils.GetPart(usPrPart, '[', ']');
            word.Pron.US = usPr;
            
            //UK Pronounce
            var ukPrPart = WebUtility.HtmlDecode(StringUtils.GetPart(response, "<div class=\"hd_pr\">", "</div>"));
            var ukPr = StringUtils.GetPart(ukPrPart, '[', ']');
            word.Pron.UK = ukPr;

            //Chinses
            var chinese = StringUtils.GetPart(response, "<span class=\"def\"><span>", "</span></span>");
            word.Chinese = chinese;
            return word;
        }
    }
}
