using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yannik.LangLearn.API.Models;
using Yannik.LangLearn.API.Services;

namespace Yannik.LangLearn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleChoiceController : ControllerBase
    {
        private readonly MultipleChoiceService _service;

        public MultipleChoiceController(MultipleChoiceService service)
        {
            _service = service;
        }

        [HttpGet("nextQuestion")]
        public async Task<IActionResult> GetNextQuestionAsync([FromQuery] string learningLanguage, [FromQuery] string questionLanguage, [FromQuery] string difficulty)
        {
            if (learningLanguage == null || !SupportedLanguage.IsLanguageSupported(learningLanguage))
            {
                return BadRequest("language is not supported");
            }

            if (difficulty == null || !SupportedDifficulty.isSupported(difficulty))
            {
                return BadRequest("difficulty is not supported");
            }

            if (string.IsNullOrEmpty(questionLanguage) || !SupportedLanguage.IsQuestionLanguageSupported(questionLanguage))
            {
                return BadRequest("Question language is not supported");
            }

            return Ok(await _service.GetQuestionWithAnswerAsync(learningLanguage, questionLanguage, difficulty));
        }
    }
}