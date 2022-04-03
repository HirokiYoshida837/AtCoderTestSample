using System;
using System.IO;
using NUnit.Framework;

namespace ABC234.Test
{
    public class ABC234ATest : TestBase
    {
        [Test]
        [TestCase("ABC234A_1")]
        [TestCase("ABC234A_2")]
        [TestCase("ABC234A_3")]
        public void Test1(string path)
        {
            var input = File.ReadAllText($@"Cases\{path}\input.txt");
            var expected = File.ReadAllText($@"Cases\{path}\expected.txt");

            Test(input, expected, () => { ABC234A.Program.Main(new String[] { }); });
        }
    }
}