namespace BlazorQuizApp.Data
{
    public class QuizData
    {
        public required string question { get; set; }
        public required List<string> Answers { get; set; }
        public required string correct { get; set; }
    }
}
