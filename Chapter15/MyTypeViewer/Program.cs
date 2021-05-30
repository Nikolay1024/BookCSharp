using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyTypeViewer
{
    class Program
    {
        enum NestedType
        { Value1, Value2 }
        static void Main()
        {
            SampleGetType();
            Type t = typeof(Math);
            ListMethods(t);
            ListFields(t);
            ListProps(t);
            ListInterfaces(t);
            ListDataType(t);
            GetGenericType();
            Console.ReadKey();
        }

        static void SampleGetType()
        {
            Console.WriteLine("=> Примеры получения информации о типе");
            Console.Write("С применением экземпляра SportsCar: ");
            SportsCar sc = new SportsCar();
            Type t = sc.GetType();
            Console.WriteLine(t);

            Console.Write("С использованием операции typeof: ");
            t = typeof(SportsCar);
            Console.WriteLine(t);

            Console.Write("Со статическим методом Туре.GetType() из текущей сборки: ");
            // (false - не генерировать исключение, если тип SportsCar не удается найти,
            // true - игнорировать регистр символов).
            t = Type.GetType("MyTypeViewer.Program", false, true);
            Console.WriteLine(t);

            Console.Write("Со статическим методом Туре.GetType() из внешней сборки: ");
            t = Type.GetType("CarLibrary.SportsCar, CarLibrary");
            Console.WriteLine(t);

            Console.Write("Со статическим методом Туре.GetType() для вложенного типа: ");
            t = Type.GetType("MyTypeViewer.Program+NestedType");
            Console.WriteLine(t);
            Console.WriteLine();
        }
        static void ListMethods(Type t)
        {
            Console.WriteLine("=> Методы");
            foreach (MethodInfo m in t.GetMethods())
            {
                // Получить информацию о возвращаемом типе.
                string retType = m.ReturnType.Name;
                // Получить информацию о параметрах.
                IEnumerable<string> paramEnum = m.GetParameters().Select(pi =>
                    string.Format("{0} {1}", pi.ParameterType.Name, pi.Name));
                string paramInfo = string.Join(", ", paramEnum);
                // Отобразить базовую сигнатуру метода.
                Console.WriteLine("{0} {1}({2});", retType, m.Name, paramInfo);
            }
            Console.WriteLine();
        }
        static void ListFields(Type t)
        {
            Console.WriteLine("=> Поля");
            var fieldNames = from f in t.GetFields() select f.Name;
            foreach (var name in fieldNames)
                Console.WriteLine(name);
            Console.WriteLine();
        }
        static void ListProps(Type t)
        {
            Console.WriteLine("=> Свойства");
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
                Console.WriteLine(name);
            Console.WriteLine();
        }
        static void ListInterfaces(Type t)
        {
            Console.WriteLine("=> Интерфейсы");
            var ifaces = from i in t.GetInterfaces() select i;
            foreach (Type i in ifaces)
                Console.WriteLine(i.Name);
            Console.WriteLine();
        }
        static void ListDataType(Type t)
        {
            Console.WriteLine("=> Данные типа");
            Console.WriteLine("Базовый тип: {0}", t.BaseType);
            Console.WriteLine("Абстрактный? {0}", t.IsAbstract);
            Console.WriteLine("Запечатанный? {0}", t.IsSealed);
            Console.WriteLine("Обобщенный? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Класс? {0}", t.IsClass);
            Console.WriteLine();
        }
        static void GetGenericType()
        {
            Console.WriteLine("=> Рефлексия обобщенных типов");
            Console.WriteLine(Type.GetType("System.Collections.Generic.List`1"));
            Console.WriteLine(Type.GetType("System.Collections.Generic.Dictionary`2"));
            Console.WriteLine();
        }
    }
}