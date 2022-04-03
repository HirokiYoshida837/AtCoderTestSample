using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ABC235A
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionA();
            var answers = question.Solve(Console.In);

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
        }
    }

    public interface IAtCoderQuestion
    {
        // 単体テスト用
        IEnumerable<object> Solve(string input);

        // 実際の回答用
        IEnumerable<object> Solve(TextReader inputStream);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public IEnumerable<object> Solve(string input)
        {
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(input));
            var reader = new StreamReader(stream, Encoding.Unicode);

            return Solve(reader);
        }

        public abstract IEnumerable<object> Solve(TextReader inputStream);
    }


    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadLine();

            var bca = new string(new[] {abc[1], abc[2], abc[0]});
            var cab = new string(new[] {abc[2], abc[0], abc[1]});

            var ans = new[] {abc, bca, cab}.ToList()
                .Select(x => int.Parse(x))
                .Sum();

            yield return ans;
        }
    }
}