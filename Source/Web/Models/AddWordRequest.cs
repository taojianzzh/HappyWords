using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Web.Models
{
    public class AddWordRequest
    {
        public string Spelling { get; set; }
        public string Chinese { get; set; }
    }
}
