using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Web.Models
{
    public class Word
    {
        public string Spelling { get; set; }
        public string Chinese { get; set; }

        public Word() { }

        public Word(Data.Models.Word word)
        {
            Spelling = word.Spelling;
            Chinese = word.Chinese;
        }
    }
}
