using CSharpFunctionalExtensions;

namespace HikiStudio.LearnVocabulary.ViewModels.Common.Pages
{
    public class PagedResponse<T>
    {
        public string? Draw { get; set; }

        public int RecordsFiltered { get; set; }

        public int RecordsTotal { get; set; }

        public List<T>? Data { get; set; }
    }
}
