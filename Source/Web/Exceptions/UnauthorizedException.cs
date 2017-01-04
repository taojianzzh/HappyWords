using HappyWords.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Web.Exceptions
{
    public class UnauthorizedException : HappyWordsException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
