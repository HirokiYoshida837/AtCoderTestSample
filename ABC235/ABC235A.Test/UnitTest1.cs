using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ABC235A.Test
{
    public class UnitTest1
    {
        IEnumerable<string> SplitByNewLine(string input) => input?.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None) ?? new string[0];
        
        [Theory]
        [InlineData(@"123", @"666")]
        [InlineData(@"999", @"2997")]
        public void QuestionATest(string input, string output)
        {
            var answers = new QuestionA().Solve(input).Select(o => o.ToString()).ToArray();

            Assert.Equal(SplitByNewLine(output), answers);
        }
    }
}