using CSharpFunctionalExtensions;

namespace HikiStudio.LearnVocabulary.ViewModels.Common.API
{
    public class APIErrorResponse<TResponse> : APIResponse<TResponse>
    {
        //public Maybe<string[]> ValidationErrors { get; set; }

        public string[]? ValidationErrors { get; set; }

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
            ValidationErrors = validationErrors;
        }

        public APIErrorResponse(Exception ex)
        {
            IsSuccessed = false;
            Message = ex.Message;
        }
    }
}
