using QuizApp.Models;

namespace QuizApp.Services{
    public class QuizManager{
        //Singleton pattern
        private static QuizManager? _instance;
        public static QuizManager Instance => _instance ??= new QuizManager();

        private int score = 0;

        //Constructor
        private QuizManager(){}

        public Question CreateQuestion(string text, List<string> options, int correctOption){
            return Question.Create(text, options,correctOption);
        }

        public Quiz CreateQuiz(List<Question> questions){
            return Quiz.Create(questions);
        }

        public void GetQuiz(Quiz quiz){
            int i;
            foreach(var question in quiz.Questions){
                i = 1;
                Console.WriteLine(question.Text);
                foreach(var option in question.Options){
                    Console.WriteLine($"{i++}.{option}");
                }
                Console.Write("Select an option: ");
                var selectedOption = int.TryParse(Console.ReadLine(),out int result) ? result : 0;
                if (selectedOption == question.CorrectOption){
                    score++;
                }
            }
            Console.WriteLine("Your score is: " + score);
        }

    }
}