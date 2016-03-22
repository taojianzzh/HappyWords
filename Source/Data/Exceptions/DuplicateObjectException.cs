using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Data.Exceptions
{
    public class DuplicateObjectException : HappyWordsException
    {
        public DuplicateObjectException(Type type, object id, Exception innerException)
            : base(string.Format("Duplicate {0} with id {1}.", type.Name, id), innerException)
        {
        }
    }
}
