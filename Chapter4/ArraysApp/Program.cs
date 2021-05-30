using System;

namespace ArraysApp
{
    class Program
    {
        static void Main()
        {
            ArrayCreateAndInit();
            ArrayOfObjects();
            RectMultidimensionalArray();
            JaggedMultidimensionalArray();
            PassAndReceiveArray();
            SystemArrayFunctionality();
            Console.ReadKey();
        }

        static void ArrayCreateAndInit()
        {
            Console.WriteLine("=> Создание и инициализация массива");
            int[] myInts = new int[2];
            myInts[0] = 0;
            myInts[1] = 1;
            Console.WriteLine(String.Join(" ", myInts));

            int[] intArray = new int[3] { 21, 22, 23 };
            Console.WriteLine(String.Join(" ", intArray));

            string[] stringArray = new string[] { "one", "two", "three", "four" };
            Console.WriteLine(String.Join(" ", stringArray));

            bool[] boolArray = { false, true };
            Console.WriteLine(String.Join(" ", boolArray));

            var doubleArray = new[] { 1.5, 2, 2.5, 3 };
            Console.WriteLine(String.Join(" ", doubleArray));

            Console.WriteLine();
        }

        static void ArrayOfObjects()
        {
            Console.WriteLine("=> Массив объектов");
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form & Void";
            foreach (object obj in myObjects)
                Console.WriteLine("Туре: {0,-20} Value: {1}", obj.GetType(), obj);
            Console.WriteLine();
        }

        static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Прямоугольный многомерный массив");
            int[,] rectArr = new int[3, 4];
            for (int i = 0; i < rectArr.GetLength(0); i++)
                for (int j = 0; j < rectArr.GetLength(1); j++)
                    rectArr[i, j] = i + j * 10;
            for (int i = 0; i < rectArr.GetLength(0); i++)
            {
                for (int j = 0; j < rectArr.GetLength(1); j++)
                    Console.Write(String.Format("{0:d2}\t", rectArr[i, j]));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Ступенчатый (зубчатый) многомерный массив");
            int[][] jaggedArr = new int[5][];
            for (int i = 0; i < jaggedArr.Length; i++)
                jaggedArr[i] = new int[i + 2];
            for (int i = 0; i < jaggedArr.Length; i++)
                for (int j = 0; j < jaggedArr[i].Length; j++)
                    jaggedArr[i][j] = i + j * 10;
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                    Console.Write(String.Format("{0:d2}\t", jaggedArr[i][j]));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PassAndReceiveArray()
        {
            Console.WriteLine("=> Передача массива в качестве входного и выходного параметра");
            int[] ages = ReceiveArray();
            PassArray(ages);
            Console.WriteLine();
        }
        static int[] ReceiveArray()
        {
            int[] ages = { 20, 22, 23, 25 };
            return ages;
        }
        static void PassArray(int[] ages)
        {
            Console.WriteLine(String.Join(" ", ages));
        }

        static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Работа с System.Array");
            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };
            Console.WriteLine("Исходный массив: {0}", String.Join(", ", gothicBands));
            Array.Reverse(gothicBands);
            Console.WriteLine("Массив в обратном порядке: {0}", String.Join(", ", gothicBands));
            Array.Clear(gothicBands, 1, 2);
            Console.WriteLine("Очистка с 1-го 2 элементов: {0}", String.Join(", ", gothicBands));
            Console.WriteLine();
        }
    }
}
