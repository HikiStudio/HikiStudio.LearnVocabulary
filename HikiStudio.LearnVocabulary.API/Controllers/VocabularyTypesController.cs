using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Application.Services;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/vocabulary-types")]
    [ApiController]
    public class VocabularyTypesController : ControllerBase
    {
        private readonly IVocabularyTypeService _vocabularyTypeService;

        public VocabularyTypesController(IVocabularyTypeService vocabularyTypeService)
        {
            _vocabularyTypeService = vocabularyTypeService;
        }

        [HttpPost("get-paging-vocabulary-types")]
        public async Task<IActionResult> GetPagingVocabularyTypes([FromBody] PagedRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vocabularyTypeService.GetPagingVocabularyTypesAsync(request);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllVocabularyTypes()
        {
            var result = await _vocabularyTypeService.GetAllVocabularyTypesAsync();
            return Ok(result);
        }

        [HttpGet("get-vocabulary-type-by-vocabulary-type-id/{vocabularyTypeID}")]
        public async Task<IActionResult> GetVocabularyTypeByVocabularyTypeID(int vocabularyTypeID)
        {
            var result = await _vocabularyTypeService.GetVocabularyTypeByVocabularyTypeIDAsync(vocabularyTypeID);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVocabularyType([FromBody] CreateVocabularyTypeRequest request)
        {
            var result = await _vocabularyTypeService.CreateVocabularyTypeAsync(request);
            return Ok(result);
        }

        [HttpPut("update/{vocabularyTypeID}")]
        public async Task<IActionResult> UpdateVocabularyType(int vocabularyTypeID, [FromBody] UpdateVocabularyTypeRequest request)
        {
            var result = await _vocabularyTypeService.UpdateVocabularyTypeAsync(request, vocabularyTypeID);
            return Ok(result);
        }

        [HttpDelete("delete/{vocabularyTypeID}")]
        public async Task<IActionResult> DeleteVocabularyType(int vocabularyTypeID)
        {
            var result = await _vocabularyTypeService.DeleteVocabularyTypeAsync(vocabularyTypeID);

            return Ok(result);
        }
    }
}
