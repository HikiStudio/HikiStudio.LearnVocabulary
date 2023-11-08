namespace HikiStudio.LearnVocabulary.Application.Interfaces
{
    public interface IMp3Service
    {
        Task<byte[]?> GetMp3Data(long audioClipID);
    }
}
