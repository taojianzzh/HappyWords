using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Core.Models
{
    public class BingDictWord
    {
        public string Spelling { get; set; }
        public BingDictPron Pron { get; set; }
        public string Chinese { get; set; }

        public BingDictWord()
        {
            Pron = new BingDictPron();
        }
    }
}
