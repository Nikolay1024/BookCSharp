using System;
using System.Collections;
using System.Collections.Generic;

namespace IssuesWithNongenericCollections
{
    class Program
    {
        static void Main()
        {
            SimpleBoxUnboxOperation();
            WorkWithArrayList();

            TryUnboxWithWrongType();
            ArrayListOfRandomObjects();
            UsePersonCollection();

            UseGenericList();
            Console.ReadKey();
        }

        static void SimpleBoxUnboxOperation()
        {
            Console.WriteLine("=> Проблема производительности необобщенных коллекций");
            // Создать переменную ValueType (int).
            int myInt = 25;
            // Упаковать int в ссылку на object.
            object boxedInt = myInt;
            // Распаковать ссылку обратно в int.
            int unboxedInt = (int)boxedInt;
            Console.WriteLine("Значение int: {0}", unboxedInt);
            Console.WriteLine();
        }
        static void WorkWithArrayList()
        {
            Console.WriteLine("-> Операции упаковки/распаковки");
            // Типы значений автоматически упаковываются при передаче
            // методу, который требует экземпляр типа object.
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);
            // Распаковка происходит, когда объект преобразуется
            // обратно в данные, расположенные в стеке.
            int i = (int)myInts[0];
            // Теперь значение вновь упаковывается, т.к.
            // метод WriteLine() требует типа object.
            Console.WriteLine("Значение int: {0}", i);
            Console.WriteLine();
        }

        static void TryUnboxWithWrongType()
        {
            Console.WriteLine("=> Проблема безопасности типов необобщенных коллекций");
            Console.WriteLine("-> Распаковка требует подходящий тип данных");
            int myInt = 25;
            object boxedInt = myInt;

            // Распаковать в неподходящий тип данных (long).
            try
            { long unboxedLong = (long)boxedInt; }
            catch (InvalidCastException ex)
            { Console.WriteLine(ex.Message); }
            Console.WriteLine();
        }
        static void ArrayListOfRandomObjects()
        {
            Console.WriteLine("-> Необобщенные коллекции хранят объекты типа Object");
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            allMyObjects.Add(66);
            allMyObjects.Add(3.14);
            foreach (var obj in allMyObjects)
                Console.WriteLine(obj);
            Console.WriteLine();
        }
        static void UsePersonCollection()
        {
            Console.WriteLine("-> Использование строго типизированной коллекции");
            PersonCollection myPeople = new PersonCollection();
            myPeople.AddPerson(new Person("Homer", "Simpson", 40));
            myPeople.AddPerson(new Person("Marge", "Simpson", 38));
            myPeople.AddPerson(new Person("Lisa", "Simpson", 9));
            myPeople.AddPerson(new Person("Bart", "Simpson", 7));
            myPeople.AddPerson(new Person("Maggie", "Simpson", 2));
            // Это вызовет ошибку на этапе компиляции!
            // myPeople.AddPerson("Name");
            foreach (Person p in myPeople)
                Console.WriteLine(p);
            Console.WriteLine();
        }

        static void UseGenericList()
        {
            Console.WriteLine("=> Обобщенные коллекции");
            // Этот объект List<> может хранить только объекты Person.
            List<Person> myPeople = new List<Person>();
            myPeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(myPeople[0]);
            // Этот объект List<> может хранить только целые числа.
            List<int> myInts = new List<int>();
            myInts.Add(10);
            myInts.Add(2);
            Console.WriteLine(myInts[0] + myInts[1]);
            // Ошибка на этапе компиляции!
            // myInts.Add(new Person());
        }
    }
}
