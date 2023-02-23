using Newtonsoft.Json;

namespace Yannik.LangLearn.API.Models
{
    public class MultipleChoiceAnswerItem
    {
        private string _answer = string.Empty;
        private string _phonetic = string.Empty;
        private bool _isCorrect;

        public string Text
        { set { _answer = value; } }

        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public string Phonetic
        {
            get { return _phonetic; }
            set { _phonetic = value; }
        }

        public bool IsCorrect
        {
            get { return _isCorrect; }
            set { _isCorrect = value; }
        }

        public bool Correct
        { set { _isCorrect = value; } }
    }
}