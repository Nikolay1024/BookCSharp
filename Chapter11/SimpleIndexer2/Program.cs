using System;
using System.Data;

namespace SimpleIndexer2
{
    class Program
    {
        static void Main()
        {
            SimpleIndexer();
            MultiIndexerWithDataTable();
            MultiIndexer();
            Console.ReadKey();
        }

        static void SimpleIndexer()
        {
            Console.WriteLine("=> Индексация данных с использованием строковых значений");
            PersonCollection myPeople = new PersonCollection();
            // Добавить объекты с применением синтаксиса индексатора.
            myPeople["Homer"] = new Person("Homer", "Simpson", 40);
            myPeople["Marge"] = new Person("Marge", "Simpson", 38);
            // Получить объект лица Homer и вывести данные.
            Console.WriteLine(myPeople["Homer"]);
            Console.WriteLine();
        }
        static void MultiIndexerWithDataTable()
        {
            Console.WriteLine("=> Многомерные индексаторы");
            // Создать простой объект DataTable с тремя столбцами.
            DataTable myTable = new DataTable();
            myTable.Columns.Add(new DataColumn("Имя"));
            myTable.Columns.Add(new DataColumn("Фамилия"));
            myTable.Columns.Add(new DataColumn("Возраст"));
            // Добавить строку в таблицу.
            myTable.Rows.Add("Mel", "Appleby", 60);
            // Использовать многомерный индексатор для вывода деталей первой строки.
            Console.WriteLine("Имя: {0}", myTable.Rows[0][0]);
            Console.WriteLine("Фамилия: {0}", myTable.Rows[0][1]);
            Console.WriteLine("Возраст : {0}", myTable.Rows[0][2]);
            Console.WriteLine();
        }
        static void MultiIndexer()
        {
            Console.WriteLine("=> Многомерный индексатор");
            SomeContainer container = new SomeContainer();
            for (int i = 0; i < container.GetLength(0); i++)
                for (int j = 0; j < container.GetLength(1); j++)
                    container[i, j] = i * 10 + j;
            for (int i = 0; i < container.GetLength(0); i++)
            {
                for (int j = 0; j < container.GetLength(1); j++)
                    Console.Write(container[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
