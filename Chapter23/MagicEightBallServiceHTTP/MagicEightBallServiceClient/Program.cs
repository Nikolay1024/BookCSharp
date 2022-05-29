// Местоположение прокси.
using MagicEightBallServiceClient.ServiceReference1;
using System;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Задайте вопрос 8-Ball");
            using (var eightBallClient = new EightBallClient())
            {
                Console.Write("Твой вопрос: ");
                string question = Console.ReadLine();
                string answer = eightBallClient.ObtainAnswerToQuestion(question);
                Console.WriteLine("8-Ball говорит: {0}", answer);
            }
            Console.ReadLine();
        }
    }
}
