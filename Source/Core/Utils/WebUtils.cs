using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Core.Utils
{
    public static class WebUtils
    {
        public static string Get(string url)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            var getStringTask = httpClient.GetStringAsync(url);
            getStringTask.Wait();
            return getStringTask.Result;
        }
    }
}
