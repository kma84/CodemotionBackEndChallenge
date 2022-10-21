
namespace CodemotionBackEndChallenge.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ProblemAttribute : Attribute
    {
        public string ProblemName { get; set; } = string.Empty;
        public int ProblemNumber { get; set; }
    }
}
