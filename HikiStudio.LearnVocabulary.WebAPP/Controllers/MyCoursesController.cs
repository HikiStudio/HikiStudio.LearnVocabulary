using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.APIIntegration.Services;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    [Route("my-courses")]
    public class MyCoursesController : Controller
    {
        private readonly ICourseAPIClient _courseAPIClient;

        private readonly IFavouriteCourseAPIClient _favouriteCourseAPIClient;

        public MyCoursesController(ICourseAPIClient courseAPIClient, IFavouriteCourseAPIClient favouriteCourseAPIClient)
        {
            _courseAPIClient = courseAPIClient;
            _favouriteCourseAPIClient = favouriteCourseAPIClient;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseAPIClient.GetAllAsync();

            if(courses != null)
            {
                ViewData["Courses"] = courses;
            }

            return View();
        }

        [HttpGet("change-favourite-course/{courseID}")]
        public async Task<IActionResult> ChangeFavouriteCourse(int courseID)
        {
            var result = await _favouriteCourseAPIClient.ChangeFavouriteCourseAsync(courseID);
            return Ok(result);
        }
    }
}
