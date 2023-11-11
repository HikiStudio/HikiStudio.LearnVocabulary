using HikiStudio.LearnVocabulary.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/favourite-courses")]
    [ApiController]
    public class FavouriteCoursesController : ControllerBase
    {
        private readonly IFavouriteCourseService _favouriteCourseService;

        public FavouriteCoursesController(IFavouriteCourseService favouriteCourseService)
        {
            _favouriteCourseService = favouriteCourseService;
        }


        [HttpGet("change-favourite-course/{courseID}")]
        public async Task<IActionResult> ChangeFavouriteCourse(int courseID)
        {
            var result = await _favouriteCourseService.ChangeFavouriteCourseAsync(courseID);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateFavouriteCourse([FromBody] int courseID)
        {
            var result = await _favouriteCourseService.CreateFavouriteCourseAsync(courseID);
            return Ok(result);
        }

        [HttpDelete("delete/{courseID}")]
        public async Task<IActionResult> UpdateVocabularyType(int courseID)
        {
            var result = await _favouriteCourseService.DeleteFavouriteCourseAsync(courseID);
            return Ok(result);
        }
    }
}
