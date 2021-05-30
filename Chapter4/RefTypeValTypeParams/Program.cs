using System;

namespace RefTypeValTypeParams
{
    class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Display()
        {
            Console.WriteLine("Имя: {0}, лет: {1}", Name, Age);
        }
    }

    class Program
    {
        static void Main()
        {
            PassRefType();
            Console.ReadKey();
        }

        static void PassRefType()
        {
            Console.WriteLine("=> Передача ссылочных типов по значению");
            Person fred = new Person("Fred", 12);
            fred.Display();
            PassRefTypeByValue(fred);
            fred.Display();
            Console.WriteLine();

            Console.WriteLine("=> Передача ссылочных типов по ссылке");
            Person mel = new Person("Mel", 23);
            mel.Display();
            PassRefTypeByReference(ref mel);
            mel.Display();
            Console.WriteLine();

        }
        static void PassRefTypeByValue(Person p)
        {
            p.Age = 55;
            p = new Person("Nikki", 99);
        }
        static void PassRefTypeByReference(ref Person p)
        {
            p.Age = 555;
            p = new Person("Nikki", 999);
        }
    }
}
