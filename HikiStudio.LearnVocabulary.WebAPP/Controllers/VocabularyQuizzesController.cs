using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.WebAPP.Controllers
{
    [Route("vocabulary-quizzes")]
    public class VocabularyQuizzesController : Controller
    {
        private readonly IVocabularyTypeAPIClient _vocabularyTypeAPIClient;

        public VocabularyQuizzesController(IVocabularyTypeAPIClient vocabularyTypeAPIClient)
        {
            _vocabularyTypeAPIClient = vocabularyTypeAPIClient;
        }

        public async Task<IActionResult> Index()
        {
            var vocabularyTypes = await _vocabularyTypeAPIClient.GetAllVocabularyTypesAsync();
            ViewData["VocabularyTypes"] = vocabularyTypes.ResultObj;

            return View();
        }
    }
}
