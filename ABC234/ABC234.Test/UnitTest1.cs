using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ABC234A;
using NUnit.Framework;

namespace ABC234.Test
{
    public class ABC234ATest
    {
        // [SetUp]
        // public void Setup()
        // {
        // }

        [Test]
        public void Test1()
        {
            var input = ReadToEnd(@"C:\Users\hirok\Documents\Code\2022\atcoder\AtCoderTemplateSample\AtCoderTemplateSample\ABC234\ABC234.Test\Cases\ABC234A_1\input.txt");
            var expected = ReadToEnd(@"C:\Users\hirok\Documents\Code\2022\atcoder\AtCoderTemplateSample\AtCoderTemplateSample\ABC234\ABC234.Test\Cases\ABC234A_1\expected.txt");
            
            var inStream = new MemoryStream();
            var outBuilder = new StringBuilder();
            var errorBuilder = new StringBuilder();
            Console.SetIn(new StreamReader(inStream));
            Console.SetOut(new StringWriter(outBuilder));
            Trace.Listeners.Add(new TextWriterTraceListener(new StringWriter(errorBuilder)));
            Console.SetError(new StringWriter(errorBuilder));
            var bytes = Encoding.UTF8.GetBytes(input);
            inStream.Write(bytes, 0, bytes.Length);
            inStream.Position = 0;
            SetStreamToReader(inStream);
        
            RunProgram();

            var res = outBuilder.ToString();

            var validate = Validate(res, expected);
            if (validate)
            {
                return;
            }
            else
            {
                throw new Exception("error");
            }
            
        }
        
        private bool Validate(string res, string expected)
        {
            var sharpedRes = string.Join("\n", res.Trim((char)0x0d, (char)0x0a).Split('\n').Select(x => x.Trim()).Where(x => x.Length != 0));
            var sharpedExpected = string.Join("\n", expected.Trim((char)0x0d, (char)0x0a).Split('\n').Select(x => x.Trim()).Where(x => x.Length != 0));

            return sharpedRes == sharpedExpected;
        }

        private static void RunProgram()
        {
            P.Main();
        }
        
        private static void SetStreamToReader(Stream stream)
        {
            var reader = Type.GetType("Reader, C-Sharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            if (reader is null) return;
            var streamField = reader.GetField("Stream", BindingFlags.NonPublic | BindingFlags.Static);
            streamField.SetValue(null, stream);
        }

        private static string ReadToEnd(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        
    }
}