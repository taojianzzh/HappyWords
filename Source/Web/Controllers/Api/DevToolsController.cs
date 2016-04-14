using HappyWords.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HappyWords.Web.Controllers.Api
{
    [RoutePrefix("api/devTools")]
    public class DevToolsController : ApiController
    {
        private static readonly HashSet<char> _ignoredPronChars = new HashSet<char>(new char[] { 'ˈ', '(', ')', ',', ',', 'ː', 'ˌ', '\'', '.', ' ' });

        [Route("GetProns", Name = "GetPronsApi")]
        public List<string> GetPronChars()
        {
            var words = WordRepository.Get();
            var pronChars = words.Where(w => !string.IsNullOrWhiteSpace(w.USPron))
                                 .SelectMany(w => w.USPron.ToCharArray()).ToList();

            var prons = new List<string>();
            for (int i = 0; i < pronChars.Count; i++)
            {
                var c = pronChars[i];
                if (_ignoredPronChars.Contains(c))
                {
                    continue;
                }

                if (c != ':')
                {
                    prons.Add(c.ToString());
                }
                else
                {
                    prons.Add(pronChars[i - 1].ToString() + c.ToString());
                }
            }

            return prons.Distinct().ToList();
        }
    }
}
