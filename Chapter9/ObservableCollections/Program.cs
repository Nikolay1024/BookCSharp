using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ObservableCollections
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Наблюдаемая коллекция");
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };
            // Привязаться к событию CollectionChanged.
            people.CollectionChanged += people_CollectionChanged;
            people.Add(new Person { FirstName = "Fred", LastName = "Smith", Age = 32 });
            people.RemoveAt(0);
            Console.ReadKey();
        }
        static void people_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Действие, которое привело к генерации события: {0}", e.Action);
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Старые элементы:");
                foreach (Person p in e.OldItems)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Новые элементы:");
                foreach (Person p in e.NewItems)
                    Console.WriteLine(p);
                Console.WriteLine();
            }
        }
    }
}
