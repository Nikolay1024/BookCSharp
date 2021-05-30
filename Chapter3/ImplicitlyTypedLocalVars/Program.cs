using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    class Program
    {
        static void Main()
        {
            DeclareImplicitVars();
            LinqQueryOverInts();
            Console.ReadKey();
        }

        static void DeclareImplicitVars()
        {
            Console.WriteLine("=> Неявная типизация (var)");
            var mylnt = 0;
            var myBool = true;
            var myString = "Строка";
            Console.WriteLine("myInt имеет тип {0}", mylnt.GetType().Name);
            Console.WriteLine("myBool имеет тип {0}", myBool.GetType().Name);
            Console.WriteLine("myString имеет тип {0}", myString.GetType().Name);
            Console.WriteLine();
        }

        static void LinqQueryOverInts()
        {
            Console.WriteLine("=> Использование var для LINQ-запросов");
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            var subset = from i in numbers where i < 10 select i;
            Console.Write("Значения в subset: ");
            foreach (var i in subset)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("subset имеет тип {0}", subset.GetType().Name);
            Console.WriteLine("subset определен в пространстве имен {0}", subset.GetType().Namespace);
        }
    }
}
