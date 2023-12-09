using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.ViewModels.Common.Pages;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IVocabularyLearningLogAPIClient _vocabularyLearningLogAPIClient;

        private readonly ICourseAPIClient _courseAPIClient;

        public HomeController(IVocabularyLearningLogAPIClient vocabularyLearningLogAPIClient, 
            ILogger<HomeController> logger,
            ICourseAPIClient courseAPIClient)
        {
            _vocabularyLearningLogAPIClient = vocabularyLearningLogAPIClient;
            _logger = logger;
            _courseAPIClient = courseAPIClient;
        }

        public async Task<IActionResult> Index()
        {
            await _courseAPIClient.GenerateDailyCourseAsync();
            return View();
        }

        [HttpPost("get-paging-vocabulary-learning-logs")]
        public async Task<IActionResult> VocabularyLearningLogs()
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

                var data = await _vocabularyLearningLogAPIClient.GetPagingVocabularyLearningLogAsync(pagedRequest);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-statistics-vocabulary-learning/{days}")]
        public async Task<IActionResult> GetStatisticsVocabularyLearning(int days)
        {
            var result = await _vocabularyLearningLogAPIClient.GetStatisticsVocabularyLearningAsync(days);

            return Ok(result);
        }
    }
}