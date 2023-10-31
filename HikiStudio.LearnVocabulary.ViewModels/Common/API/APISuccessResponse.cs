namespace HikiStudio.LearnVocabulary.ViewModels.Common.API
{
    public class APISuccessResponse<TResponse> : APIResponse<TResponse>
    {
        public APISuccessResponse(TResponse resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }

        public APISuccessResponse()
        {
            IsSuccessed = true;
            Message = "Successful.";
        }

        public APISuccessResponse(string message)
        {
            IsSuccessed = true;
            Message = message;
        }
    }
}
