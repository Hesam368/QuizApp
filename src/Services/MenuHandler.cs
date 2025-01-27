using Microsoft.Extensions.DependencyInjection;
using QuizApp.Models;

namespace QuizApp.Services
{
    public class MenuHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<string, Func<IGetQuiz>> _quizSources;

        public MenuHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _quizSources = new Dictionary<string, Func<IGetQuiz>>
            {
                { "1", () => _serviceProvider.GetRequiredService<ManualQuizCreation>() },
                { "2", () => _serviceProvider.GetRequiredService<JsonQuizCreation>() },
            };
        }

        public IGetQuiz? DisplayMenu()
        {
            Console.WriteLine("\n--- Quiz Application ---");
            Console.WriteLine("1. Start Manual Quiz");
            Console.WriteLine("2. Start Quiz from JSON");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string? input = Console.ReadLine();

            if (_quizSources.TryGetValue(input ?? string.Empty, out var quizSource))
            {
                return quizSource();
            }

            if (input == "3")
            {
                return null;
            }

            Console.WriteLine("Invalid option! Please try again.");
            return DisplayMenu();
        }
    }
}
