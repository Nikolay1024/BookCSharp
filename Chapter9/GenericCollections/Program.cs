using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main()
        {
            UseGenericList();
            UseGenericStack();
            UseGenericQueue();
            UseSortedSet();
            UseDictionary();
            Console.ReadKey();
        }

        static void UseGenericList()
        {
            Console.WriteLine("=> Обобщенный список");
            // Создать список объектов Person и заполнить его с помощью
            // синтаксиса инициализации объектов и коллекции.
            List<Person> listPeople = new List<Person>()
            {
                new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 },
                new Person { FirstName = "Bart", LastName = "Simpson", Age = 8 }
            };
            Console.WriteLine("Элементов в списке: {0}", listPeople.Count);
            foreach (Person person in listPeople)
                Console.WriteLine(person);

            // Вставить новый объект Person в позицию 2.
            listPeople.Insert(2, new Person { FirstName = "Maggie", LastName = "Simpson", Age = 2 });
            Console.WriteLine("Элементов в списке: {0}", listPeople.Count);

            // Скопировать данные в новый массив.
            Person[] arrayPeople = listPeople.ToArray();
            foreach (Person person in arrayPeople)
                Console.WriteLine("Имя: {0}", person.FirstName);
            Console.WriteLine();
        }

        static void UseGenericStack()
        {
            Console.WriteLine("=> Обобщенный стек");
            Stack<Person> stackPeople = new Stack<Person>();
            stackPeople.Push(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackPeople.Push(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackPeople.Push(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            Console.WriteLine("Возвращает верхний объект стека:\n  {0}", stackPeople.Peek());
            Console.WriteLine("Возвращает верхний объект стека и удаляет его:\n  {0}", stackPeople.Pop());
            Console.WriteLine(stackPeople.Pop());
            Console.WriteLine(stackPeople.Pop());
            try
            { Console.WriteLine(stackPeople.Pop()); }
            catch (InvalidOperationException ex)
            { Console.WriteLine(ex.Message); }
            Console.WriteLine();
        }

        static void UseGenericQueue()
        {
            Console.WriteLine("=> Обобщенная очередь");
            Queue<Person> queuePeople = new Queue<Person>();
            queuePeople.Enqueue(new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            queuePeople.Enqueue(new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            queuePeople.Enqueue(new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            // Заглянуть, кто первый в очереди.
            Console.WriteLine("{0} первый в очереди!", queuePeople.Peek().FirstName);
            // Удалить всех из очереди.
            GetCoffee(queuePeople.Dequeue());
            GetCoffee(queuePeople.Dequeue());
            GetCoffee(queuePeople.Dequeue());
            // Попробовать извлечь кого-то из очереди снова.
            try
            { GetCoffee(queuePeople.Dequeue()); }
            catch (InvalidOperationException ex)
            { Console.WriteLine(ex.Message); }
            Console.WriteLine();
        }
        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0}, кофе!", p.FirstName);
        }

        static void UseSortedSet()
        {
            Console.WriteLine("=> Обобщенное сортированное множество");
            // Создать несколько объектов Person с разными значениями возраста.
            SortedSet<Person> setPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 },
                new Person { FirstName = "Bart", LastName = "Simpson", Age = 8 }
            };
            // Обратите внимание, что элементы отсортированы по возрасту.
            foreach (Person р in setPeople)
                Console.WriteLine(р);
            Console.WriteLine();
            // Добавить еще несколько объектов Person с разными значениями возраста.
            setPeople.Add(new Person { FirstName = "Saku", LastName = "Jones", Age = 1 });
            setPeople.Add(new Person { FirstName = "Mikko", LastName = "Jones", Age = 32 });
            // Элементы по-прежнему отсортированы по возрасту.
            foreach (Person p in setPeople)
                Console.WriteLine(p);
            Console.WriteLine();
        }

        static void UseDictionary()
        {
            Console.WriteLine("=> Обобщенный словарь");
            // Наполнить с помощью метода Add().
            Dictionary<string, Person> dictPeople = new Dictionary<string, Person>();
            dictPeople.Add("Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            dictPeople.Add("Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            dictPeople.Add("Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            // Получить элемент с ключом Homer.
            Console.WriteLine(dictPeople["Homer"]);
            // Наполнить с помощью синтаксиса инициализации.
            dictPeople = new Dictionary<string, Person>()
            {
                { "Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 } },
                { "Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } },
                { "Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 } }
            };
            // Получить элемент с ключом Lisa.
            Console.WriteLine(dictPeople["Lisa"]);
            // Наполнить с помощью синтаксиса инициализации словаря.
            dictPeople = new Dictionary<string, Person>()
            {
                ["Homer"] = new Person { FirstName = "Homer", LastName = "Simpson", Age = 47 },
                ["Marge"] = new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 },
                ["Lisa"] = new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 }
            };
            // Получить элемент с ключом Marge.
            Console.WriteLine(dictPeople["Marge"]);
            Console.WriteLine();
        }
    }
}
