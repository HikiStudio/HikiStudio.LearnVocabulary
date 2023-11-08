namespace HikiStudio.LearnVocabulary.APIIntegration.Interfaces
{
    public interface IMp3APIClient
    {
        Task<byte[]?> GetMp3Data(long audioClipID);
    }
}
