using System.Text.Json;
using QuizApp.Models;

namespace QuizApp.Services
{
    public class QuizManager : IQuizManager
    {
        //Singleton pattern
        // private static QuizManager? _instance;
        // public static QuizManager Instance => _instance ??= new QuizManager();

        private int score = 0;

        //Constructor
        //private QuizManager(){}

        public Quiz CreateQuiz(IGetQuiz quizSource)
        {
            var questions = quizSource.RetrieveQuestions();
            return Quiz.Create(questions);
        }

        public void GetQuiz(Quiz quiz)
        {
            score = 0;
            foreach (var question in quiz.Questions)
            {
                PresentQuestion(question);
            }
        }

        private void PresentQuestion(Question question)
        {
            Console.WriteLine(question.Text);
            for (int i = 1; i <= question.Options.Count; i++)
            {
                Console.WriteLine($"{i}.{question.Options[i - 1]}");
            }
            while (true)
            {
                Console.Write("Select an option: ");
                var selectedOption = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                if (result > 0 && result <= question.Options.Count)
                {
                    if (selectedOption == question.CorrectOption)
                    {
                        score++;
                    }
                    break;
                }
                Console.WriteLine("Invalid option! Please select a valid option.");
            }
        }

        public void DisplaySummary(Quiz quiz)
        {
            Console.WriteLine("Quiz Summary:");
            Console.WriteLine("Total Questions: " + quiz.Questions.Count);
            Console.WriteLine("Correct Answers: " + score);
            Console.WriteLine("Wrong Answers: " + (quiz.Questions.Count - score));
            Console.WriteLine("Score from 100: " + (score * 100 / quiz.Questions.Count));
        }
    }
}
