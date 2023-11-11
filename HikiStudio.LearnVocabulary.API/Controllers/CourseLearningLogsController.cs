using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Utilities.Constants;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.CourseLearningLogs.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/course-learning-logs")]
    [ApiController]
    public class CourseLearningLogsController : ControllerBase
    {
        private readonly ICourseLearningLogService _courseLearningLogService;

        public CourseLearningLogsController(ICourseLearningLogService courseLearningLogService)
        {
            _courseLearningLogService = courseLearningLogService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCourseLearningLog(CreateCourseLearningLogRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new APIErrorResponse<bool>() { Message = MessageConstants.ModelStateIsNotValid(nameof(CreateCourseLearningLogRequest)) });

            var result = await _courseLearningLogService.CreateCourseLearningLogAsync(request);

            return Ok(result);
        }

        [HttpPost("get-paging-course-learning-logs/{courseID}")]
        public async Task<IActionResult> GetPagingCourseLearningLogByCourseID([FromBody] PagedRequest request, int courseID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _courseLearningLogService.GetPagingCourseLearningLogByCourseIDAsync(request, courseID);
            return Ok(result);
        }
    }
}
