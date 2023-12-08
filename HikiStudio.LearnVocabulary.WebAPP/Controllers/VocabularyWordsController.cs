using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyRelationships.DataRequest;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    [Route("vocabulary-words")]
    public class VocabularyWordsController : Controller
    {
        private readonly IVocabularyTypeAPIClient _vocabularyTypeAPIClient;

        private readonly IVocabularyWordAPIClient _vocabularyWordAPIClient;

        private readonly IVocabularyRelationshipAPIClient _vocabularyRelationshipAPIClient;

        private readonly IMp3APIClient _mp3APIClient;

        public VocabularyWordsController(IVocabularyWordAPIClient vocabularyWordAPIClient, 
            IVocabularyTypeAPIClient vocabularyTypeAPIClient, IMp3APIClient mp3APIClient, 
            IVocabularyRelationshipAPIClient vocabularyRelationshipAPIClient)
        {
            _vocabularyTypeAPIClient = vocabularyTypeAPIClient;
            _vocabularyWordAPIClient = vocabularyWordAPIClient;
            _mp3APIClient = mp3APIClient;
            _vocabularyRelationshipAPIClient = vocabularyRelationshipAPIClient;
        }

        public async Task<IActionResult> Index()
        {
            var vocabularyTypes = await _vocabularyTypeAPIClient.GetAllVocabularyTypesAsync();
            ViewData["VocabularyTypes"] = vocabularyTypes.ResultObj;

            var vocabularyWords = await _vocabularyWordAPIClient.GetAllVocabularyWordAsync(1);
            ViewData["VocabularyWords"] = vocabularyWords;

            return View();
        }

        [HttpGet("get-all-vocabulary-words/{vocabularyTypeID}")]
        public async Task<IActionResult> GetAllVocabularyWords(int? vocabularyTypeID)
        {
            var result = await _vocabularyWordAPIClient.GetAllVocabularyWordAsync(vocabularyTypeID);
            return Ok(result);
        }

        [HttpPost("get-paging-vocabulary-words/{vocabularyTypeID}")]
        public async Task<IActionResult> VocabularyWords(int? vocabularyTypeID)
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var orderBy = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumn = Request.Form[$"columns[{orderBy}][name]"].FirstOrDefault()?.Replace(" ", "");
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                var pagedRequest = new PagedRequest()
                {
                    Draw = draw,
                    Start = start,
                    Length = length,
                    SortColumn = sortColumn,
                    SortColumnDirection = sortColumnDirection,
                    SearchValue = searchValue,
                    PageSize = pageSize,
                    Skip = skip,
                    RecordsTotal = recordsTotal
                };

                var data = await _vocabularyWordAPIClient.GetPagingVocabularyWordAsync(pagedRequest, vocabularyTypeID);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-vocabulary-word-by-vocabulary-word-id/{vocabularyWordID}")]
        public async Task<IActionResult> GetVocabularyWordByVocabularyWordID(long vocabularyWordID)
        {
            var result = await _vocabularyWordAPIClient.GetVocabularyWordByVocabularyWordIDAsync(vocabularyWordID);
            return Ok(result);
        }

        [HttpGet("get-vocabulary-word-by-course-id/{courseID}")]
        public async Task<IActionResult> GetVocabularyWordByCourseID(int courseID)
        {
            var result = await _vocabularyWordAPIClient.GetVocabularyWordByCourseIDAsync(courseID);
            return Ok(result);
        }

        [HttpPost("create-vocabulary-word")]
        public async Task<IActionResult> CreateVocabularyWord([FromBody] CreateVocabularyWordRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new APIErrorResponse<int>(MessageConstants.ModelStateIsNotValid(nameof(CreateVocabularyWordRequest))));

            var result = await _vocabularyWordAPIClient.CreateVocabularyWordAsync(request);

            return Ok(result);
        }

        [HttpPut("update-vocabulary-word/{vocabularyWordID}")]
        public async Task<IActionResult> UpdateVocabularyWord([FromBody] UpdateVocabularyWordRequest request, int vocabularyWordID)
        {
            if (!ModelState.IsValid)
                return Ok(new APIErrorResponse<bool>(MessageConstants.ModelStateIsNotValid(nameof(UpdateVocabularyWordRequest))));

            var result = await _vocabularyWordAPIClient.UpdateVocabularyWordAsync(request, vocabularyWordID);

            return Ok(result);
        }

        [HttpDelete("delete-vocabulary-word/{vocabularyWordID}")]
        public async Task<IActionResult> DeleteVocabularyWord(long vocabularyWordID)
        {
            var result = await _vocabularyWordAPIClient.DeleteVocabularyWordAsync(vocabularyWordID);

            return Ok(result);
        }

        [HttpGet("audios/open/{audioClipID}")]
        public async Task<IActionResult> GetMp3Data(long audioClipID)
        {
            try
            {
                byte[]? mp3Data = await _mp3APIClient.GetMp3Data(audioClipID);
                if (mp3Data != null)
                {
                    return File(mp3Data, "audio/mpeg", audioClipID.ToString());
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-vocabulary-relationship-by-vocabulary-word-id/{vocabularyWordID}")]
        public async Task<IActionResult> GetVocabularyRelationshipByVocabularyWordID(long vocabularyWordID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vocabularyRelationshipAPIClient.GetVocabularyRelationshipByVocabularyWordIDAsync(vocabularyWordID);
            return Ok(result);
        }

        [HttpPost("assign-vocabulary-relationship/{vocabularyWordID}")]
        public async Task<IActionResult> AssignVocabularyRelationship([FromBody] List<AssignVocabularyRelationshipRequest> requests, long vocabularyWordID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _vocabularyRelationshipAPIClient.AssignVocabularyRelationshipAsync(requests, vocabularyWordID);
            return Ok(result);
        }
    }
}
