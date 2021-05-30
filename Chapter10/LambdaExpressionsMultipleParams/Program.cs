using System;

namespace LambdaExpressionsMultipleParams
{
    public class SimpleMath
    {
        public delegate void MathMessage(string msg, int result);
        private MathMessage mmDelegate;
        public void SetMathHandler(MathMessage target)
        {
            mmDelegate = target;
        }
        public void Add(int x, int y)
        {
            mmDelegate?.Invoke("Сложение", x + y);
        }
    }
    class Program
    {
        static void Main()
        {
            // Зарегистрировать делегат как лямбда-выражение.
            SimpleMath m = new SimpleMath();
            m.SetMathHandler((msg, result) =>
            {
                Console.WriteLine("Сообщение: {0}. Результат: {1}", msg, result);
            });
            // Это приведет к выполнению лямбда-выражения.
            m.Add(10, 10);
            Console.ReadKey();
        }
    }
}
