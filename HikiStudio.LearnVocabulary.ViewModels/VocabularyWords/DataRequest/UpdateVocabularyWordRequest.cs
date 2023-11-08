namespace HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest
{
    public class UpdateVocabularyWordRequest
    {
        public int VocabularyTypeID { get; set; }

        public string Word { get; set; } = string.Empty;

        public string Definition { get; set; } = string.Empty;

        public string? Pronunciation { get; set; }

        public string? ExampleSentence { get; set; }

        public string? ExampleSentenceMeaning { get; set; }


        public string? Synonyms { get; set; }

        public string? Antonyms { get; set; }

        public string? ImageURL { get; set; }
    }
}
