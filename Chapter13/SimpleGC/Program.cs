using System;

namespace SimpleGC
{
    class Program
    {
        static void Main()
        {
            GCMembers();
            GCTest();
            Console.ReadKey();
        }

        static void GCMembers()
        {
            Console.WriteLine("=> Члены System.GC");
            Console.WriteLine("Оценочное количество байтов, выделенных в куче: {0}",
                GC.GetTotalMemory(false));
            Console.WriteLine("Число поколений, поддерживаемое системой: {0}",
                GC.MaxGeneration + 1);
            Car car = new Car("Zippy", 100);
            Console.WriteLine("Поколение объекта Car({0}): {1}",
                car, GC.GetGeneration(car));
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine();
        }
        static void GCTest()
        {
            Console.WriteLine("=> Тест сборщика мусора");
            object[] objects = new object[50000];
            for (int i = 0; i < 50000; i++)
                objects[i] = new object();
            // Выполнить сборку мусора только для объектов поколения 0.
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            // Посмотреть, существует ли еще objects[9000].
            if (objects[9000] != null)
                Console.WriteLine("Поколение объекта objects[9000]: {0}",
                    GC.GetGeneration(objects[9000]));
            else
                Console.WriteLine("objects[9000] был удален");
            Console.WriteLine("Произведено сборок мусора {0} в 0 поколении",
                GC.CollectionCount(0));
            Console.WriteLine("Произведено сборок мусора {0} в 1 поколении",
                GC.CollectionCount(1));
            Console.WriteLine("Произведено сборок мусора {0} во 2 поколении",
                GC.CollectionCount(2));
            Console.WriteLine();
        }
    }
}
