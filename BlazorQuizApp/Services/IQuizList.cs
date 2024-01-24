namespace BlazorQuizApp.Services
{
    public interface IQuizList
    {
        Task<List<string>> GetFilesAsync();
    }
}
