namespace HikiStudio.LearnVocabulary.Utilities.Constants
{
    public class SystemConstants
    {
        public class AppSettings
        {
            public const string BaseAddress = "BaseAddress";

            public const string MainConnectionString = "LanguageLearningDB";

            /// <summary>
            /// The default language is English with ID = 1
            /// </summary>
            public const int LanguageDefaultID = 1;

            /// <summary>
            /// The default pronunciation is English-American with ID = 1
            /// </summary>
            public const int PronunciationTypeDefaultID = 1;

            public static readonly Guid CreateByDefault = new Guid("0B64F6F0-9F60-45C9-9E7B-F68CCC3FC57F");

            public const string URLDownloadFileMP3 = "https://api.soundoftext.com/sounds";

            public const string URLFolderSaveVocabularyWord = "E:\\HikiStudio\\HikiStudio.Stored\\HikiStudio.LearnVocabulary";
        }
    }
}
