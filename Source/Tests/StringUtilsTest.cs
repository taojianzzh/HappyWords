using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyWords.Core.Utils;

namespace HappyWords.Tests
{
    [TestClass]
    public class StringUtilsTest
    {
        [TestMethod]
        public void StartWithSymbol()
        {
            string s = "<<abc>>xxx";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.AreEqual("abc", part);
        }

        [TestMethod]
        public void EndWithSymbol()
        {
            string s = "xxx<<abc>>";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.AreEqual("abc", part);
        }

        [TestMethod]
        public void PartInMiddle()
        {
            string s = "xxx<<abc>>xxx";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.AreEqual("abc", part);
        }

        [TestMethod]
        public void NotFound()
        {
            string s = "<<abc>>";
            string part = StringUtils.GetPart(s, "x", "y");
            Assert.AreEqual(string.Empty, part);
        }

        [TestMethod]
        public void NothingAmongSymbols()
        {
            string s = "x<<>>x";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.AreEqual(string.Empty, part);
        }
    }
}
