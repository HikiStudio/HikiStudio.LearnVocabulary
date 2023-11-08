using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyLearningLogs.DataRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/vocabulary-learning-logs")]
    [ApiController]
    public class VocabularyLearningLogsController : ControllerBase
    {
        private readonly IVocabularyLearningLogService _vocabularyLearningLogService;

        public VocabularyLearningLogsController(IVocabularyLearningLogService vocabularyLearningLogService)
        {
            _vocabularyLearningLogService = vocabularyLearningLogService;
        }

        [HttpPost("get-paging-vocabulary-learning-logs")]
        public async Task<IActionResult> GetPagingVocabularyLearningLog([FromBody] PagedRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vocabularyLearningLogService.GetPagingVocabularyLearningLogAsync(request);
            return Ok(result);
        }

        [HttpGet("read")]
        public async Task<IActionResult> ReadVocabularyLearningLog()
        {
            var result = await _vocabularyLearningLogService.ReadVocabularyLearningLog();

            return Ok(result);
        }

        [HttpPost("write")]
        public async Task<IActionResult> WriteVocabularyLearningLog([FromBody] WriteVocabularyLearningLogRequest request)
        {
            var duration = new TimeSpan(request.Hours, request.Minutes, request.Seconds);

            var result = await _vocabularyLearningLogService.WriteVocabularyLearningLog(duration);
            return Ok(result);
        }
    }
}
