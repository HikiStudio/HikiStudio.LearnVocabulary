namespace HikiStudio.LearnVocabulary.ViewModels.VocabularyWords
{
    public class VocabularyWordViewModel
    {
        public long VocabularyWordID { get; set; }

        public int VocabularyTypeID { get; set; }

        public int LanguageID { get; set; }

        public string Word { get; set; } = string.Empty;

        public string Definition { get; set; } = string.Empty;

        public string? Pronunciation { get; set; }

        public string? ExampleSentence { get; set; }

        public string? Synonyms { get; set; }

        public string? Antonyms { get; set; }

        public string? ImageURL { get; set; }
    }
}
