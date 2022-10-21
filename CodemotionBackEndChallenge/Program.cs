
using CodemotionBackEndChallenge.Core;
using CodemotionBackEndChallenge.Core.Interfaces;


int? problemNumber = null;
if (args.Length == 1 && int.TryParse(args[0], out int num))
    problemNumber = num;

RunProblems(problemNumber);


void RunProblems(int? problemNumber)
{
    var iProblemType = typeof(IProblem);
    var problemTypes = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(a => a.GetTypes())
        .Where(t => iProblemType.IsAssignableFrom(t) && t.IsClass)
        .OrderBy(t => t.Name);

    foreach (Type problemType in problemTypes)
    {
        var problemAttribute = (ProblemAttribute)problemType.GetCustomAttributes(typeof(ProblemAttribute), true).First();

        if (problemAttribute != null && (!problemNumber.HasValue || problemAttribute.ProblemNumber == problemNumber.Value))
        {
            IProblem? problem = (IProblem?)Activator.CreateInstance(problemType);
            string input = File.ReadAllText(GetInputPath(problemAttribute.ProblemNumber, problem?.Debug ?? false));

            Console.WriteLine($"Problem: {problemAttribute.ProblemName}");
            Console.WriteLine($"Solution: {problem?.Solve(input)}");
            Console.WriteLine();
        }
    }
}


string GetInputPath(int problemNumber, bool debug) => GetProblemBasePath(problemNumber) + (debug ? "debugInput.txt" : "input.txt");

string GetProblemBasePath(int problemNumber) => $"{AppDomain.CurrentDomain.BaseDirectory}Problem{problemNumber}{Path.DirectorySeparatorChar}";
