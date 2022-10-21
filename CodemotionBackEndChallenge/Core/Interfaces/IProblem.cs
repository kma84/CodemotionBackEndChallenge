
namespace CodemotionBackEndChallenge.Core.Interfaces
{
    internal interface IProblem
    {
        string Solve(string input);

        bool Debug { get => false; set { } }
    }
}
