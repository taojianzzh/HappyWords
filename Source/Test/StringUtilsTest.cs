using System;
using HappyWords.Core.Utils;
using Xunit;

namespace HappyWords.Test
{
    public class StringUtilsTest
    {
        [Fact]
        public void StartWithSymbol()
        {
            string s = "<<abc>>xxx";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.Equal("abc", part);
        }

        [Fact]
        public void EndWithSymbol()
        {
            string s = "xxx<<abc>>";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.Equal("abc", part);
        }

        [Fact]
        public void PartInMiddle()
        {
            string s = "xxx<<abc>>xxx";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.Equal("abc", part);
        }

        [Fact]
        public void NotFound()
        {
            string s = "<<abc>>";
            string part = StringUtils.GetPart(s, "x", "y");
            Assert.Equal(string.Empty, part);
        }

        [Fact]
        public void NothingAmongSymbols()
        {
            string s = "x<<>>x";
            string part = StringUtils.GetPart(s, "<<", ">>");
            Assert.Equal(string.Empty, part);
        }
    }
}
