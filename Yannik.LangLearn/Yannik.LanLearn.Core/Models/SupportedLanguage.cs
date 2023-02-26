namespace Yannik.LangLearn.Core.Models
{
    public static class SupportedLanguage
    {
        public static List<string> Languages { get; } = new List<string>() { "German", "English", "French", "Italian", "Ukrainian", "Czech", "Spanish" };
        public static List<string> QuestionLanguages { get; } = new List<string>() { "German", "English" };

        public static bool IsLanguageSupported(string lang) => Languages.Contains(lang);

        public static bool IsQuestionLanguageSupported(string lang) => Languages.Contains(lang);
    }
}