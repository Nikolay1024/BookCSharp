using System;

namespace MagicEightBallServiceLib
{
    public class MagicEightBallService : IEightBall
    {
        // Просто для отображения на хосте.
        public MagicEightBallService()
        {
            Console.WriteLine("8-Ball ожидает твоего вопроса...");
        }
        public string ObtainAnswerToQuestion(string userQuestion)
        {
            string[] answers = { "Будущее неопределенно", "Да", "Нет", "Туманно", "Спросите позже", "Определенно" };
            // Возвратить случайный ответ.
            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }
}
