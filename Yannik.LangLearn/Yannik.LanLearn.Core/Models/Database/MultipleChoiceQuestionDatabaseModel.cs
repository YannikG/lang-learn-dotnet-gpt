namespace Yannik.LanLearn.Core.Models.Database
{
    public class MultipleChoiceQuestionDatabaseModel : BaseDatabaseEntityModel
    {
        public string LearningLanguage { get; set; } = string.Empty;
        public string QuestionLangauge { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public List<MultipleChoiceAnswerDatabaseModel> Answers { get; set; } = new List<MultipleChoiceAnswerDatabaseModel>();
    }
}