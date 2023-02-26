﻿namespace Yannik.LangLearn.Core.Models.OpenAI
{
    public class MultipleChoiceQuestionAndAnswers
    {
        public string Question { get; set; } = string.Empty;
        public List<MultipleChoiceAnswerItem> Answers { get; set; } = new List<MultipleChoiceAnswerItem>();
    }
}