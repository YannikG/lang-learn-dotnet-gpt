namespace Yannik.LangLearn.API.Models
{
    public class SupportedDifficulty
    {
        public static List<string> Difficulties { get; } = new List<string>() { "Beginner", "Elementary", "Pre-Intermediate", "Intermediate", "Upper-Intermediate", "Advanced" };

        public static bool isSupported(string difficulty) => Difficulties.Contains(difficulty);
    }
}