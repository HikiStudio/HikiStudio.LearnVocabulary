using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.Courses.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    [Route("vocabulary-courses")]
    public class VocabularyCoursesController : Controller
    {
        private readonly ICourseAPIClient _courseAPIClient;

        private readonly IVocabularyWordAPIClient _vocabularyWordAPIClient;

        public VocabularyCoursesController(ICourseAPIClient courseAPIClient, IVocabularyWordAPIClient vocabularyWordAPIClient)
        {
            _courseAPIClient = courseAPIClient;
            _vocabularyWordAPIClient = vocabularyWordAPIClient;
        }

        public async Task<IActionResult> Index()
        {
            var vocabularyWords = await _vocabularyWordAPIClient.GetAllVocabularyWordAsync(1);
            ViewData["VocabularyWords"] = vocabularyWords;

            return View();
        }

        [HttpPost("get-paging-courses")]
        public async Task<IActionResult> Courese()
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

                var data = await _courseAPIClient.GetPagingCourseAsync(pagedRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-course")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new APIErrorResponse<int>(MessageConstants.ModelStateIsNotValid(nameof(CreateCourseRequest))));

            var result = await _courseAPIClient.CreateCourseAsync(request);

            return Ok(result);
        }

        [HttpGet("get-course-by-course-id/{courseID}")]
        public async Task<IActionResult> GetCourseByCourseID(int courseID)
        {
            var result = await _courseAPIClient.GetCourseByCourseIDAsync(courseID);
            return Ok(result);
        }

        [HttpPut("update-course/{courseID}")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseRequest request, int courseID)
        {
            if (!ModelState.IsValid)
                return Ok(new APIErrorResponse<bool>(MessageConstants.ModelStateIsNotValid(nameof(UpdateCourseRequest))));

            var result = await _courseAPIClient.UpdateCourseAsync(request, courseID);

            return Ok(result);
        }

        [HttpDelete("delete-course/{courseID}")]
        public async Task<IActionResult> DeleteCourse(int courseID)
        {
            var result = await _courseAPIClient.DeleteCourseAsync(courseID);

            return Ok(result);
        }
    }
}
