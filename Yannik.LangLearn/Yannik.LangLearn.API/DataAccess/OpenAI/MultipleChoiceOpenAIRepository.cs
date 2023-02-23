﻿using Yannik.LangLearn.API.DataAccess.Database;
using Yannik.LangLearn.API.Models.Database;
using Yannik.LangLearn.API.Models.OpenAI;

namespace Yannik.LangLearn.API.DataAccess.OpenAI
{
    public class MultipleChoiceOpenAIRepository
    {
        private readonly OpenAIClientWrapper _client;

        public MultipleChoiceOpenAIRepository(OpenAIClientWrapper client)
        {
            _client = client;
        }

        public async Task<MultipleChoiceQuestionAndAnswers?> GetQuestionWithAnswerAsync(string learningLanguage, string questionLanguage, string difficutly)
        {
            string prompt = $"Using the {questionLanguage} language, generate an {difficutly} level multiple-choice question to help learners of {learningLanguage}. Include in the question words and sentences to translate. Include a boolean flag in the answer array to indicate whether each answer is correct or incorrect, and provide the phonetic representation for each answer as a separate property. Return the entire response as a JSON object with English property names. The response MUST be a valid JSON object!";
            var result = await _client.PromptAsyncWithResponse<MultipleChoiceQuestionAndAnswers>(prompt);

            return result;
        }
    }
}