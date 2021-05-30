using System;

namespace CustomConversions
{
    class Program
    {
        static void Main()
        {
            ExplicitUserDefinedConversions();
            ImplicitUserDefinedConversions();
            Console.ReadKey();
        }

        static void ExplicitUserDefinedConversions()
        {
            Console.WriteLine("=> Явные специальные преобразования типов");
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
            rect.Draw();
            // Явно преобразовать Rectangle в Square на основе высоты.
            Square sq1 = (Square)rect;
            Console.WriteLine(sq1);
            sq1.Draw();
            Console.WriteLine();

            // Явно преобразовать Int в Square.
            Square sq2 = (Square)4;
            Console.WriteLine(sq2);
            sq2.Draw();
            // Явно преобразовать Square в Int.
            Console.WriteLine("Длина стороны квадрата = {0}", (int)sq2);
            Console.WriteLine();
        }
        static void ImplicitUserDefinedConversions()
        {
            Console.WriteLine("=> Неявные специальные преобразования типов");
            // Неявное преобразование работает!
            Square sq1 = new Square(3);
            Rectangle rect1 = sq1;
            Console.WriteLine(rect1);
            // Синтаксис явного приведения также работает!
            Square sq2 = new Square(2);
            Rectangle rect2 = (Rectangle)sq2;
            Console.WriteLine(rect2);
            Console.WriteLine();
        }
    }
}