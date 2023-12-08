using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    [Route("common-regular-verbs")]
    public class CommonRegularVerbsController : Controller
    {
        private readonly ILogger<CommonRegularVerbsController> _logger;

        private readonly IVocabularyLearningLogAPIClient _vocabularyLearningLogAPIClient;

        public CommonRegularVerbsController(
            IVocabularyLearningLogAPIClient vocabularyLearningLogAPIClient,
            ILogger<CommonRegularVerbsController> logger)
        {
            _vocabularyLearningLogAPIClient = vocabularyLearningLogAPIClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}