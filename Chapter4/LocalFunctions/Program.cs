using System;

namespace LocalFunctions
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(AddWrapper(10, 9));
            Console.ReadKey();
        }

        static int AddWrapper(int x, int y)
        {
            // Выполнить здесь проверку достоверности
            return Add();
            int Add()
            {
                return x + y;
            }
        }
    }
}
