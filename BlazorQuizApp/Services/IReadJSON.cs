using BlazorQuizApp.Data;

namespace BlazorQuizApp.Services
{
    public interface IReadJSON
    {
        Task<List<QuizData>> LoadQuestions(string path);
        List<QuizData> ShuffleQuestions(List<QuizData> quizData);
        List<QuizData> ShuffleAnswers(List<QuizData> quizData);
    }
}
