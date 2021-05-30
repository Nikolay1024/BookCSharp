using System;

namespace UnsafeCode
{
    class Program
    {
        static void Main()
        {
            SimplePointer();
            PrintValueAndAddress();

            SwapTest();

            UsePointerToPoint();
            UnsafeStackAlloc();
            UseAndPinPointRef();

            UseSizeOfOperator();
            Console.ReadKey();
        }

        static void SimplePointer()
        {
            Console.WriteLine("=> Указатели");
            int myInt = 10;
            unsafe
            {
                // Здесь работаем с указателями!
                Node2.SquareIntPointer(&myInt);
            }
            Console.WriteLine("myInt = {0}", myInt);
            Console.WriteLine();
        }
        static unsafe void PrintValueAndAddress()
        {
            Console.WriteLine("=> Работа с операциями * и &");
            int myInt;
            // Определить указатель на int и присвоить ему адрес myInt.
            int* ptrToInt = &myInt;
            // Присвоить значение myInt, используя обращение через указатель.
            *ptrToInt = 123;
            Console.WriteLine("(Значение myInt) myInt = {0}", myInt);
            Console.WriteLine("(Значение myInt) *ptrToInt = {0}", *ptrToInt);
            Console.WriteLine("(Адрес myInt) &myInt = {0:X}", (int)&myInt);
            Console.WriteLine("(Адрес myInt) ptrToInt = {0:X}", (int)ptrToInt);
            Console.WriteLine();
        }

        static void SwapTest()
        {
            Console.WriteLine("=> Небезопасный (и безопасный) метод обмена");
            int int1 = 5, int2 = 10;
            Console.WriteLine("До обмена: int1 = {0}; int2 = {1}", int1, int2);
            unsafe { UnsafeSwap(&int1, &int2); }
            Console.WriteLine("После небезопасного обмена: int1 = {0}; int2 = {1}", int1, int2);
            SafeSwap(ref int1, ref int2);
            Console.WriteLine("После безопасного обмена: int1 = {0}; int2 = {1}", int1, int2);
            Console.WriteLine();
        }
        static unsafe void UnsafeSwap(int* int1, int* int2)
        {
            int temp = *int1;
            *int1 = *int2;
            *int2 = temp;
        }
        static void SafeSwap(ref int int1, ref int int2)
        {
            int temp = int1;
            int1 = int2;
            int2 = temp;
        }

        static unsafe void UsePointerToPoint()
        {
            Console.WriteLine("=> Доступ к открытым членам типа через указатели (операция ->)");
            // Доступ к членам через указатель.
            Point point1;
            Point* ptrPoint1 = &point1;
            ptrPoint1->X = 100;
            ptrPoint1->Y = 200;
            Console.WriteLine(ptrPoint1->ToString());
            // Доступ к членам через разыменованный указатель.
            Point point2;
            Point* ptrPoint2 = &point2;
            (*ptrPoint2).X = 100;
            (*ptrPoint2).Y = 200;
            Console.WriteLine((*ptrPoint2).ToString());
            Console.WriteLine();
        }
        static unsafe void UnsafeStackAlloc()
        {
            Console.WriteLine("=> Ключевое слово stackalloc");
            char* p = stackalloc char[256];
            for (int i = 0; i < 256; i++)
            {
                p[i] = (char)i;
                Console.Write(p[i] + " ");
            }
            Console.WriteLine("\n");
        }
        static unsafe void UseAndPinPointRef()
        {
            Console.WriteLine("=> Закрепление типа посредством ключевого слова fixed");
            PointRef point = new PointRef() { X = 5, Y = 6 };
            // Закрепить указатель point на месте, чтобы он не мог
            // быть перемещен или уничтожен сборщиком мусора.
            fixed (int* p = &point.X)
            {
                // Использовать здесь переменную int*!
                Console.WriteLine("point.X = {0}", *p);
            }
            // Указатель point теперь не закреплен и готов
            // к сборке мусора после завершения метода.
            Console.WriteLine(point);
            Console.WriteLine();
        }
        static unsafe void UseSizeOfOperator()
        {
            Console.WriteLine("=> Ключевое слово sizeof");
            Console.WriteLine("Размер short {0}.", sizeof(short));
            Console.WriteLine("Размер int {0}.", sizeof(int));
            Console.WriteLine("Размер long {0}.", sizeof(long));
            Console.WriteLine("Размер Point {0}.", sizeof(Point));
            Console.WriteLine();
        }
    }
}
