using System;
using System.Collections.Generic;

namespace SimpleIndexer
{
    class Program
    {
        static void Main()
        {
            SimpleIndexer();
            UseGenericListOfPeople();
            Console.ReadKey();
        }

        static void SimpleIndexer()
        {
            Console.WriteLine("=> Индексированные методы");
            PersonCollection myPeople = new PersonCollection();
            // Добавить объекты с применением синтаксиса индексатора.
            myPeople[0] = new Person("Homer", "Simpson", 40);
            myPeople[1] = new Person("Marge", "Simpson", 38);
            myPeople[2] = new Person("Lisa", "Simpson", 9);
            myPeople[3] = new Person("Bart", "Simpson", 7);
            myPeople[4] = new Person("Maggie", "Simpson", 2);
            // Получить и отобразить элементы, используя индексатор.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Номер: {0}", i);
                Console.WriteLine("Имя: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Возраст: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void UseGenericListOfPeople()
        {
            Console.WriteLine("=> Обобщенная коллекция List<> поддерживает индексатор");
            List<Person> myPeople = new List<Person>();
            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));
            // Изменить первый объект лица с помощью индексатора.
            myPeople[0] = new Person("Maggie", "Simpson", 2);
            // Получить и отобразить каждый элемент, используя индексатор.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Номер: {0}", i);
                Console.WriteLine("Имя: {0} {1}", myPeople[i].FirstName,
                myPeople[i].LastName);
                Console.WriteLine("Возраст: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }
    }
}
