using HikiStudio.LearnVocabulary.APIIntegration;
using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    [Route("vocabulary-quizzes")]
    public class VocabularyQuizzesController : Controller
    {
        private readonly IVocabularyTypeAPIClient _vocabularyTypeAPIClient;

        private readonly ICourseLearningLogAPIClient _courseLearningLogAPIClient;

        public VocabularyQuizzesController(IVocabularyTypeAPIClient vocabularyTypeAPIClient, ICourseLearningLogAPIClient courseLearningLogAPIClient)
        {
            _vocabularyTypeAPIClient = vocabularyTypeAPIClient;
            _courseLearningLogAPIClient = courseLearningLogAPIClient;
        }

        public async Task<IActionResult> Index(int? courseID)
        {
            var vocabularyTypes = await _vocabularyTypeAPIClient.GetAllVocabularyTypesAsync();
            ViewData["VocabularyTypes"] = vocabularyTypes.ResultObj;

            ViewBag.CourseID = courseID;

            return View();
        }
        [HttpPost("get-paging-course-learning-logs/{courseID}")]
        public async Task<IActionResult> VocabularyWords(int courseID)
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

                var data = await _courseLearningLogAPIClient.GetPagingCourseLearningLogByCourseIDAsync(pagedRequest, courseID);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create-course-learning-log")]
        public async Task<IActionResult> CreateCourseLearningLog([FromBody] CreateCourseLearningLogRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(new APIErrorResponse<bool>(MessageConstants.ModelStateIsNotValid(nameof(CreateCourseLearningLogRequest))));

            var result = await _courseLearningLogAPIClient.CreateCourseLearningLogAsync(request);

            return Ok(result);
        }

    }
}
