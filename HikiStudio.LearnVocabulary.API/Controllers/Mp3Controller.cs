using HikiStudio.LearnVocabulary.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HikiStudio.LearnVocabulary.API.Controllers
{
    [Route("api/mp3")]
    [ApiController]
    public class Mp3Controller : ControllerBase
    {
        private readonly IMp3Service _mp3Service;

        public Mp3Controller(IMp3Service mp3Service)
        {
            _mp3Service = mp3Service;
        }

        [HttpGet]
        [Route("open/{audioClipID}")]
        public async Task<IActionResult> GetMp3(long audioClipID)
        {
            try
            {
                byte[]? mp3Data = await _mp3Service.GetMp3Data(audioClipID);
                if (mp3Data != null)
                {
                    return File(mp3Data, "audio/mpeg", audioClipID.ToString());
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
