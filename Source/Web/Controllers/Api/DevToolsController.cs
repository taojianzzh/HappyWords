using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HappyWords.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace HappyWords.Web.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class DevToolsController : Controller
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
