using BlazorQuizApp.Data;
using System.Text.Json;

namespace BlazorQuizApp.Services
{
    public class ReadJSON : IReadJSON
    {
        public async Task<List<QuizData>> LoadQuestions(string path)
        {
            try
            {
                // Use StreamReaderAsync to read the contents asynchronously.
                using (StreamReader reader = new StreamReader(path))
                {
                    // Read the contents asynchronously.
                    string json = await reader.ReadToEndAsync();
                    // Create a JsonSerializerOptions object to specify the options for deserializing the JSON data.
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.PropertyNameCaseInsensitive = true;
                    // Deserialize the JSON data into a strongly typed object using the JsonSerializer.Deserialize<T>() method.
                    return JsonSerializer.Deserialize<List<QuizData>>(json, options)!;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Δεν Βρέθηκε το Αρχείο");
                return new List<QuizData>();
            }
            catch (IOException ex)
            {
                // Handle other I/O exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<QuizData>();
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Σφάλμα: {exp}");
                return new List<QuizData>();
            }
        }

        public List<QuizData> ShuffleQuestions(List<QuizData> quizData)
        {
            Random random = new Random();
            return quizData.OrderBy(x => random.Next()).ToList();
        }

        public List<QuizData> ShuffleAnswers(List<QuizData> quizData)
        {
            Random random = new Random();
            foreach (var question in quizData)
            {
                question.Answers = question.Answers.OrderBy(x => random.Next()).ToList();
            }
            return quizData;
        }
    }
}
