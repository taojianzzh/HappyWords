using HappyWords.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Core.Interfaces
{
    public interface IBingDictService
    {
        BingDictWord Get(string spelling);
    }
}
