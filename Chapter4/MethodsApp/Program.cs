using System;

namespace MethodsApp
{
    class Program
    {
        static void Main()
        {
            PassParams();
            ReceiveParams();
            OptionalArguments();
            NamedArguments();
            Console.ReadKey();
        }

        static void PassParams()
        {
            Console.WriteLine("=> Передача параметра по значению");
            int x = 10, y = 9;
            int sum = PassByValue(x, y);
            Console.WriteLine("{0} + {1} = {2}\n\r", x, y, sum);

            Console.WriteLine("=> Передача параметра по ссылке");
            int mul = 0;
            PassByReference(x, y, ref mul);
            Console.WriteLine("{0} * {1} = {2}\n\r", x, y, mul);

            Console.WriteLine("=> Передача (по ссылке) выходного параметра");
            PassByOutput(x, y, out int sub);
            Console.WriteLine("{0} - {1} = {2}\n\r", x, y, sub);

            Console.WriteLine("=> Передача (по ссылке) входного параметра");
            int div = PassByInput(in x, in y);
            Console.WriteLine("{0} / {1} = {2}\n\r", x, y, div);

            Console.WriteLine("=> Передача массива параметров");
            double average;
            average = PassByParams(2, 2.5, 3, 3.5, 4);
            Console.WriteLine("Среднее значение массива чисел на лету: {0}", average);
            double[] data = { 4.0, 5.5, 7.0 };
            average = PassByParams(data);
            Console.WriteLine("Среднее значение массива в переменной {0}: {1}",
                String.Join(", ", data), average);
            Console.WriteLine("Среднее значение пустого массива: {0}\n\r", PassByParams());

            Console.WriteLine("=> Передача выходного параметра с пустой переменной (отбрасыванием)");
            double pow = PassByDiscard(x, y, out double _);
            Console.WriteLine("{0} ^ {1} = {2}\n\r", x, y, pow);
        }
        static int PassByValue(int x, int y)
        {
            int sum = x + y;
            x = 100;
            y = 90;
            return sum;
        }
        static void PassByReference(int x, int y, ref int mul)
        {
            mul = x * y;
            return;
        }
        static void PassByOutput(int x, int y, out int sub)
        {
            sub = x - y;
            return;
        }
        static int PassByInput(in int x, in int y)
        {
            int div = x / y;
            return div;
        }
        static double PassByParams(params double[] doubleArr)
        {
            double sum = 0;
            if (doubleArr.Length == 0)
                return sum;
            foreach (double myDouble in doubleArr)
                sum += myDouble;
            return sum / doubleArr.Length;
        }
        static double PassByDiscard(int x, int y, out double pow)
        {
            pow = Math.Pow(x, y);
            return pow;
        }

        static void ReceiveParams()
        {
            Console.WriteLine("=> Прием параметра по ссылке");
            string[] strArr = { "one", "two", "three" };
            int pos = 1;
            ref string refStr = ref ReceiveByReference(strArr, pos);
            refStr = "NEW";
            Console.WriteLine(String.Join(", ", strArr) + "\n\r");
        }
        static ref string ReceiveByReference(string[] strArr, int pos)
        {
            return ref strArr[pos];
        }

        static void OptionalArguments()
        {
            Console.WriteLine("=> Необязательные параметры");
            Message("Сообщение");
            Message("Fatal error", "System");
            Console.WriteLine();
        }
        static void Message(string msg, string own = "Программист")
        {
            Console.WriteLine("Ошибка: {0}\tВладелец: {1}", msg, own);
        }

        static void NamedArguments()
        {
            Console.WriteLine("=> Именованные параметры");
            Message(dt: DateTime.Now, msg:"Сообщение", own:"Программист");
            Message("Fatal error", dt:DateTime.Now, own: "System");
            Console.WriteLine();
        }
        static void Message(string msg, string own, DateTime dt)
        {
            Console.WriteLine("Ошибка: {0}\tВладелец: {1}\tДата: {2:d}", msg, own, dt);
        }
    }
}
