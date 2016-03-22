using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Data.Exceptions
{
    public class HappyWordsException : Exception
    {
        public HappyWordsException(string message) : base(message)
        {
        }

        public HappyWordsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
