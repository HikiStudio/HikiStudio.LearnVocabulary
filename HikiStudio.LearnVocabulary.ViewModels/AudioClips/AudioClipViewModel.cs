using HikiStudio.LearnVocabulary.ViewModels.Base;

namespace HikiStudio.LearnVocabulary.ViewModels.AudioClips
{
    public class AudioClipViewModel : BaseViewModel<Guid>
    {
        public long AudioClipID { get; set; }

        public long VocabularyWordID { get; set; }

        public int PronunciationTypeID { get; set; }

        public string AudioURL { get; set; } = String.Empty;
    }
}
