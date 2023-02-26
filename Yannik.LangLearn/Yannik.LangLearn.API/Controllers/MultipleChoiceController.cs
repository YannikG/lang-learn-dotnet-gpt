using Microsoft.AspNetCore.Mvc;
using Yannik.LanLearn.Core.Models;
using Yannik.LanLearn.Core.Services;

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
        public async Task<IActionResult> GetNextQuestionAsync([FromQuery] string learningLanguage, [FromQuery] string questionLanguage)
        {
            if (learningLanguage == null || !SupportedLanguage.IsLanguageSupported(learningLanguage))
            {
                return BadRequest("language is not supported");
            }

            if (string.IsNullOrEmpty(questionLanguage) || !SupportedLanguage.IsQuestionLanguageSupported(questionLanguage))
            {
                return BadRequest("Question language is not supported");
            }

            return Ok(await _service.GetNextMultipleChoicesAsync(learningLanguage, questionLanguage));
        }

        [HttpGet("generateQuestion")]
        public async Task<IActionResult> GenerateNextQuestionAsync([FromQuery] string learningLanguage, [FromQuery] string questionLanguage, [FromQuery] string topic)
        {
            if (learningLanguage == null || !SupportedLanguage.IsLanguageSupported(learningLanguage))
            {
                return BadRequest("language is not supported");
            }

            if (string.IsNullOrEmpty(questionLanguage) || !SupportedLanguage.IsQuestionLanguageSupported(questionLanguage))
            {
                return BadRequest("Question language is not supported");
            }

            await _service.GenerateAndStoreMultipleChoiceAsync(learningLanguage, questionLanguage, topic);

            return NoContent();
        }
    }
}