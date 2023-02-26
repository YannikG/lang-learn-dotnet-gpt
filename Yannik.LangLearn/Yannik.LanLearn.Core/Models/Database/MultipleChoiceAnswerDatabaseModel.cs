namespace Yannik.LangLearn.Core.Models.Database
{
    public class MultipleChoiceAnswerDatabaseModel
    {
        public string Answer { get; set; } = string.Empty;
        public string Phonetic { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}