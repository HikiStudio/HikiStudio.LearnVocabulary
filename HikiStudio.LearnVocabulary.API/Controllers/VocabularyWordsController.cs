using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/vocabulary-words")]
    [ApiController]
    public class VocabularyWordsController : ControllerBase
    {
        private readonly IVocabularyWordService _vocabularyWordService;

        private readonly ITempVocabularyWordService _tempVocabularyWordService;

        public VocabularyWordsController(IVocabularyWordService vocabularyWordService, ITempVocabularyWordService tempVocabularyWordService)
        {
            _vocabularyWordService = vocabularyWordService;
            _tempVocabularyWordService = tempVocabularyWordService;
        }

        [HttpGet("save")]
        public async Task<IActionResult> Save()
        {
            //var result = await _tempVocabularyWordService.SaveDataTempToDB();

            //return Ok(result);

            return Ok();
        }

        [HttpPost("get-paging-vocabulary-words/{vocabularyTypeID?}")]
        public async Task<IActionResult> GetPagingVocabularyWord([FromBody] PagedRequest request, int? vocabularyTypeID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vocabularyWordService.GetPagingVocabularyWordAsync(request, vocabularyTypeID);
            return Ok(result);
        }

        [HttpGet("get-all-vocabulary-words/{vocabularyTypeID?}")]
        public async Task<IActionResult> GetAllVocabularyWord(int? vocabularyTypeID)
        {
            var result = await _vocabularyWordService.GetAllVocabularyWordAsync(vocabularyTypeID);
            return Ok(result);
        }

        [HttpGet("get-vocabulary-word-by-vocabulary-word-id/{vocabularyWordID?}")]
        public async Task<IActionResult> GetVocabularyWordByVocabularyWordID(int vocabularyWordID)
        {
            var result = await _vocabularyWordService.GetVocabularyWordByVocabularyWordIDAsync(vocabularyWordID);
            return Ok(result);
        }

        [HttpGet("get-vocabulary-word-by-course-id/{courseID}")]
        public async Task<IActionResult> GetVocabularyWordByCourseID(int courseID)
        {
            var result = await _vocabularyWordService.GetVocabularyWordByCourseIDAsync(courseID);
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
