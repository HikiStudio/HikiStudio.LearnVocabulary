using CSharpFunctionalExtensions;
using HikiStudio.LearnVocabulary.Utilities.Enums;

namespace HikiStudio.LearnVocabulary.ViewModels.Common.API
{
    public class APIResponse<TResponse>
    {
        public bool IsSuccessed { get; set; }

        public Maybe<string> Message { get; set; }

        public StatusCodeEnum StatusCode { get; set; }

        public Maybe<TResponse> ResultObj { get; set; }
    }
}
