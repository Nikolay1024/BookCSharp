using System;
using System.Data.SqlClient;

namespace ICloneableExample
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Интерфейсы");
            // Все эти классы поддерживают интерфейс ICloneable.
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            SqlConnection sqlCnn = new SqlConnection();
            // Следовательно, все они могут быть переданы методу,
            // принимающему параметр типа ICloneable.
            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);
            Console.ReadKey();
        }

        static void CloneMe(ICloneable clone)
        {
            object myClone = clone.Clone();
            Console.WriteLine("Клон: {0}", myClone.GetType().Name);
        }
    }
}
