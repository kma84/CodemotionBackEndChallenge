using CodemotionBackEndChallenge.Core;
using CodemotionBackEndChallenge.Core.Interfaces;

namespace CodemotionBackEndChallenge.Problem1
{
    [Problem(ProblemName = "FizzBuzz", ProblemNumber = 0)]
    internal class Problem0 : IProblem
    {
        public string Solve(string input)
        {
            return string.Join(Environment.NewLine, FizzBuzz(int.Parse(input)));
        }


        public static IEnumerable<string> FizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
                yield return PrintMessage(i);
        }


        public static string PrintMessage(int n) => n switch
        {
            int x when x % 5 == 0 && x % 3 == 0 => "FizzBuzz",
            int x when x % 3 == 0 => "Fizz",
            int x when x % 5 == 0 => "Buzz",
            _ => n.ToString()
        };

    }
}
