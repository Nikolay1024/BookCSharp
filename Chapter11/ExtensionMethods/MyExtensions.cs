﻿using System;
using System.Reflection;

namespace MyExtensionMethods
{
    static class MyExtensions
    {
        // Этот метод позволяет объекту любого типа
        // отобразить сборку, в которой он определен.
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("Тип {0} определен в сборке {1}", obj.GetType().Name,
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }
        // Этот метод позволяет любому целочисленному значению изменить порядок
        // следования десятичных цифр на обратный. Например, для 56 возвратится 65.
        public static int ReverseDigits(this int i)
        {
            // Транслировать int в string и затем получить все его символы.
            char[] digits = i.ToString().ToCharArray();
            // Изменить порядок следования элементов массива.
            Array.Reverse(digits);
            // Поместить обратно в строку.
            string newDigits = new string(digits);
            // Возвратить модифицированную строку как int.
            return int.Parse(newDigits);
        }
    }
}
