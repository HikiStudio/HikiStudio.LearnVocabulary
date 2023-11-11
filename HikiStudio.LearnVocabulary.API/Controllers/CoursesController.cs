using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Application.Services;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using HikiStudio.LearnVocabulary.ViewModels.Courses.DataRequest;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpPost("get-paging-courses")]
        public async Task<IActionResult> GetPagingCourse([FromBody] PagedRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _courseService.GetPagingCourseAsync(request);
            return Ok(result);
        }

        [HttpGet("generate-daily-course")]
        public async Task<IActionResult> GenerateDailyCourse()
        {
            var result = await _courseService.GenerateDailyCourseAsync();

            return Ok(result);
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseService.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("get-course-by-course-id/{courseID}")]
        public async Task<IActionResult> GetAll(int courseID)
        {
            var result = await _courseService.GetCourseByCourseIDAsync(courseID);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVocabularyType([FromBody] CreateCourseRequest request)
        {
            var result = await _courseService.CreateCourseAsync(request);
            return Ok(result);
        }

        [HttpPut("update/{courseID}")]
        public async Task<IActionResult> UpdateVocabularyType(int courseID, [FromBody] UpdateCourseRequest request)
        {
            var result = await _courseService.UpdateCourseAsync(request, courseID);
            return Ok(result);
        }

        [HttpDelete("delete/{courseID}")]
        public async Task<IActionResult> UpdateVocabularyType(int courseID)
        {
            var result = await _courseService.DeleteCourseAsync(courseID);
            return Ok(result);
        }
    }
}
