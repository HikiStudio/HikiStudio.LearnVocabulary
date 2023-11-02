namespace HikiStudio.LearnVocabulary.ViewModels.AudioClips.DataRequest
{
    public class UpdateAudioClipRequest
    {
        public long VocabularyWordID { get; set; }

        public string AudioURL { get; set; } = String.Empty;
    }
}
