using HappyWords.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HappyWords.Test
{
    public class BingDictServiceTest
    {
        [Fact]
        public void ParseApple()
        {
            var bingDictService = new BingDictService();
            var word = bingDictService.Get("apple");
            Assert.True(word.Chinese.Contains("苹果"));
            Assert.Equal("ˈæp(ə)l", word.Pron.US);
            Assert.Equal("'æpl", word.Pron.UK);
        }
    }
}
