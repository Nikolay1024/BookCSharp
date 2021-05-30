// Импорт пространств имен из библиотек базовых классов.
using System;
// Импорт пространств имен MyShapes и My3DShapes.
using MyShapes;
using My3DShapes;
// Псевдонимы типов
using The3DHex = My3DShapes.Hexagon;
using TheHex = MyShapes.Hexagon;

namespace CustomNamespaces
{
    class Program
    {
        static void Main()
        {
            FullyQualifiedTypeNames();
            AliasNamespaceOrType();
            NestedNamespaces();
            Console.ReadKey();
        }

        static void FullyQualifiedTypeNames()
        {
            Console.WriteLine("=> Разрешение конфликтов имен с помощью полностью заданных имен");
            MyShapes.Square s1 = new MyShapes.Square();
            My3DShapes.Square s2 = new My3DShapes.Square();
            Console.WriteLine();
        }
        static void AliasNamespaceOrType()
        {
            Console.WriteLine("=> Разрешение конфликтов имен с помощью псевдонимов");
            The3DHex h1 = new The3DHex();
            TheHex h2 = new TheHex();
            Console.WriteLine();
        }
        static void NestedNamespaces()
        {
            Console.WriteLine("=> Создание вложенных пространств имен");
            Chapter14.My3DShapes.Circle c1 = new Chapter14.My3DShapes.Circle();
            Chapter14.MyShapes.Circle c2 = new Chapter14.MyShapes.Circle();
            Console.WriteLine();
        }
    }
}
