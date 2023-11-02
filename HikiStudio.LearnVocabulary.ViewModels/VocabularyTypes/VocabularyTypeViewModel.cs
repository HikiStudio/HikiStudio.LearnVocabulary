using HikiStudio.LearnVocabulary.ViewModels.Base;

namespace HikiStudio.LearnVocabulary.ViewModels.VocabularyTypes
{
    public class VocabularyTypeViewModel : BaseViewModel<Guid>
    {
        public int VocabularyTypeID { get; set; }

        public string? VocabularyTypeName { get; set; }
    }
}
