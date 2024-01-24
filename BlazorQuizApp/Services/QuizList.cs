namespace BlazorQuizApp.Services
{
    public class QuizList : IQuizList
    {
        public async Task<List<string>> GetFilesAsync()
        {
            return await Task.Run(() =>
            {
                string folderPath = "Data";
                string extension = ".dat";

                return Directory.GetFiles(folderPath, $"*{extension}")
                                .Select(filePath => Path.GetFileNameWithoutExtension(filePath))
                                .ToList();
            });
        }
    }
}
