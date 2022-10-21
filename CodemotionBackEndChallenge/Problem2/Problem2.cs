using CodemotionBackEndChallenge.Core;
using CodemotionBackEndChallenge.Core.Interfaces;

namespace CodemotionBackEndChallenge.Problem2
{
    [Problem(ProblemName = "Perfect Pairs", ProblemNumber = 2)]
    internal class Problem2 : IProblem
    {

        public string Solve(string input)
        {
            List<int> numbers = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();

            return GetPerfectPairsCount(numbers).ToString();
        }


        public static long GetPerfectPairsCount(List<int> arr)
        {
            long perfectPairCount = 0;

            arr = arr.Select(n => Math.Abs(n)).OrderBy(n => n).ToList();

            int indexAnt = 1;
            bool outOfIndex = false;

            for (int i = 0; i < arr.Count; i++)
            {
                int newPerfectPairs;
                if (outOfIndex)
                {
                    newPerfectPairs = arr.Count - i - 1;
                }
                else
                {
                    int limit = arr[i] * 2;
                    int index = arr.FindIndex(indexAnt, n => n > limit);

                    if (index == -1)
                    {
                        outOfIndex = true;
                        newPerfectPairs = arr.Count - i - 1;
                    }
                    else
                    {
                        newPerfectPairs = index - 1 - i;
                        indexAnt = index;
                    }
                }

                perfectPairCount += newPerfectPairs;
            }

            return perfectPairCount;
        }

    }
}
