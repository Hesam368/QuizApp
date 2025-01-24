using System.Text.Json;
using QuizApp.Services;

namespace QuizApp.Models
{
    public class JsonQuizCreation : IGetQuiz
    {
        public List<Question> RetrieveQuestions()
        {
            Console.WriteLine("Enter the file path to the JSON file: ");
            string? filePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(filePath))
            {
                System.Console.WriteLine("Error: File path cannot be empty!");
                return new List<Question>();
            }
            return ImportQuiz(filePath);
        }

        private List<Question> ImportQuiz(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }
                string jsonContent = File.ReadAllText(filePath);
                var questions = JsonSerializer.Deserialize<List<Question>>(
                    jsonContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                if (questions == null || questions.Count == 0)
                {
                    throw new Exception("No questions found in the file!");
                }
                Console.WriteLine("Quiz was imported successfully!");
                return questions;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found!");
            }
            catch (JsonException)
            {
                Console.WriteLine("Error: Invalid JSON format!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return new List<Question>();
        }
    }
}
