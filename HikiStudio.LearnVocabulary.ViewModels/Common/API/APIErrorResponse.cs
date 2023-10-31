using CSharpFunctionalExtensions;

namespace HikiStudio.LearnVocabulary.ViewModels.Common.API
{
    public class APIErrorResponse<TResponse> : APIResponse<TResponse>
    {
        public Maybe<string[]> ValidationErrors { get; set; }

        public APIErrorResponse()
        {
        }

        public APIErrorResponse(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public APIErrorResponse(string[] validationErrors)
        {
            IsSuccessed = false;
            Message = Maybe<string>.None;
            ValidationErrors = validationErrors;
            ResultObj = Maybe<TResponse>.None;
        }

        public APIErrorResponse(Exception ex)
        {
            IsSuccessed = false;
            Message = ex.Message;
        }
    }
}
