using HappyWords.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Tests
{
    [TestClass]
    public class BingDictServiceTest
    {
        [TestMethod]
        public void ParseApple()
        {
            var word = BingDictService.Get("apple");
            Assert.IsTrue(word.Chinese.Contains("苹果"));
            Assert.AreEqual("ˈæp(ə)l", word.Pron.US);
            Assert.AreEqual("'æpl", word.Pron.UK);
        }
    }
}
