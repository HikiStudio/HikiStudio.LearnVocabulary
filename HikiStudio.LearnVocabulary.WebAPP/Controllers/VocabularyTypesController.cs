using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    [Route("vocabulary-types")]
    public class VocabularyTypesController : Controller
    {
        private readonly IVocabularyTypeAPIClient _vocabularyTypeAPIClient;

        public VocabularyTypesController(IVocabularyTypeAPIClient vocabularyTypeAPIClient)
        {
            _vocabularyTypeAPIClient = vocabularyTypeAPIClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("get-paging-vocabulary-types")]
        public async Task<IActionResult> VocabularyTypes()
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

                var data = await _vocabularyTypeAPIClient.GetPagingVocabularyTypesAsync(pagedRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-vocabulary-type")]
        public async Task<IActionResult> CreateVocabularyType([FromBody] CreateVocabularyTypeRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new APIErrorResponse<int>(MessageConstants.ModelStateIsNotValid(nameof(CreateVocabularyTypeRequest))));

            var result = await _vocabularyTypeAPIClient.CreateVocabularyTypeAsync(request);

            return Ok(result);
        }

        [HttpGet("get-vocabulary-type-by-vocabulary-type-id/{vocabularyTypeID}")]
        public async Task<IActionResult> GetVocabularyTypeByVocabularyTypeID(int vocabularyTypeID)
        {
            var result = await _vocabularyTypeAPIClient.GetVocabularyTypeByVocabularyTypeIDAsync(vocabularyTypeID);
            return Ok(result);
        }

        [HttpPut("update-vocabulary-type/{vocabularyTypeID}")]
        public async Task<IActionResult> UpdateVocabularyType([FromBody] UpdateVocabularyTypeRequest request, int vocabularyTypeID)
        {
            if (!ModelState.IsValid)
                return Ok(new APIErrorResponse<bool>(MessageConstants.ModelStateIsNotValid(nameof(UpdateVocabularyTypeRequest))));

            var result = await _vocabularyTypeAPIClient.UpdateVocabularyTypeAsync(request, vocabularyTypeID);

            return Ok(result);
        }

        [HttpDelete("delete-vocabulary-type/{vocabularyTypeID}")]
        public async Task<IActionResult> DeleteVocabularyType(int vocabularyTypeID)
        {
            var result = await _vocabularyTypeAPIClient.DeleteVocabularyTypeAsync(vocabularyTypeID);

            return Ok(result);
        }



    }
}
