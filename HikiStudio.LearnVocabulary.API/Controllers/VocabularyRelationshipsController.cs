using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.Entities;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/vocabulary-relationships")]
    [ApiController]
    public class VocabularyRelationshipsController : ControllerBase
    {
        private readonly IVocabularyRelationshipService _vocabularyRelationshipService;

        public VocabularyRelationshipsController(IVocabularyRelationshipService vocabularyRelationshipService)
        {
            _vocabularyRelationshipService = vocabularyRelationshipService;
        }


        [HttpGet("get-vocabulary-relationship-by-vocabulary-word-id/{vocabularyWordID}")]
        public async Task<IActionResult> GetVocabularyRelationshipByVocabularyWordID(long vocabularyWordID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vocabularyRelationshipService.GetVocabularyRelationshipByVocabularyWordIDAsync(vocabularyWordID);
            return Ok(result);
        }

        [HttpPost("assign-vocabulary-relationship/{vocabularyWordID}")]
        public async Task<IActionResult> AssignVocabularyRelationship([FromBody] List<AssignVocabularyRelationshipRequest> requests, long vocabularyWordID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vocabularyRelationshipService.AssignVocabularyRelationshipAsync(requests, vocabularyWordID);
            return Ok(result);
        }
    }
}
