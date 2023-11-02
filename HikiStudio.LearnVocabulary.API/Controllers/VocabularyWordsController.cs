using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/vocabulary-words")]
    [ApiController]
    public class VocabularyWordsController : ControllerBase
    {
        private readonly IVocabularyWordService _vocabularyWordService;

        public VocabularyWordsController(IVocabularyWordService vocabularyWordService)
        {
            _vocabularyWordService = vocabularyWordService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllVocabylaryWord([FromQuery] int? vocabularyTypeID = null)
        {
            var result = await _vocabularyWordService.GetAllVocabylaryWordAsync(vocabularyTypeID);
            return Ok(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateVocabularyWord([FromBody] CreateVocabularyWordRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new APIErrorResponse<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateVocabularyWordRequest))});
            }

            var result = await _vocabularyWordService.CreateVocabularyWordAsync(request);

            return Ok(result);
        }


        [HttpPut("update/{vocabularyWordID}")]
        public async Task<IActionResult> CreateVocabularyWord(long vocabularyWordID, [FromBody] UpdateVocabularyWordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIErrorResponse<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateVocabularyWordRequest)) });
            }

            var result = await _vocabularyWordService.UpdateVocabularyWordAsync(request, vocabularyWordID);

            return Ok(result);
        }

        [HttpDelete("delete/{vocabularyWordID}")]
        public async Task<IActionResult> CreateVocabularyWord(long vocabularyWordID)
        {
            var result = await _vocabularyWordService.DeleteVocabularyWordAsync(vocabularyWordID);

            return Ok(result);
        }
    }
}
