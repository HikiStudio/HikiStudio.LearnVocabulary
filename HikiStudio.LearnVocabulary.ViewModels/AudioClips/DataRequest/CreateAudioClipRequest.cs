namespace HikiStudio.LearnVocabulary.ViewModels.AudioClips.DataRequest
{
    public class CreateAudioClipRequest
    {
        public long VocabularyWordID { get; set; }

        public string AudioURL { get; set; } = String.Empty;
    }
}
