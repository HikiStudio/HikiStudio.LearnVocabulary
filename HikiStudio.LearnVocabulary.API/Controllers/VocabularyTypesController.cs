using HikiStudio.LearnVocabulary.Application.Interfaces;
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

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllVocabularyTypes()
        {
            var result = await _vocabularyTypeService.GetAllVocabularyTypesAsync();
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
    }
}
