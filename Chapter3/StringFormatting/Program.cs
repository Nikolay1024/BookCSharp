using System;
using System.Globalization;
using System.Numerics;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            FormatNumericalData();
            Console.ReadKey();
        }

        private static void FormatNumericalData()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            Console.WindowHeight = 63;
            Console.WriteLine("{0,69}", "Форматирование строк");
            Console.WriteLine("---Форматы чисел-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,57}| |{1,-57:d}|", "(d|D) Формат целых чисел", 1234);
            Console.WriteLine("|{0,57}| |{1,-57:d5}|", "(d5) дополняет до 5 '0'", 1234);
            Console.WriteLine("|{0,57}| |{1,-57:E}|", "(Е) Экспоненциальный формат", 123.456);
            Console.WriteLine("|{0,57}| |{1,-57:e2}|", "(е2) строчный регистр, с точностью 2", 123.456);
            Console.WriteLine("|{0,57}| |{1,-57:f}|", "(f|F) Формат дробных чисел", 1234.5678);
            Console.WriteLine("|{0,57}| |{1,-57:f3}|", "(f3) в дробной части 3 знака", 1234.5678);
            Console.WriteLine("|{0,57}| |{1,-57:n}|", "(n|N) Формат дробных чисел с разделителем", 1234.5678);
            Console.WriteLine("|{0,57}| |{1,-57:n4}|", "(n4) в дробной части 4 знака", 1234.5678);
            Console.WriteLine("|{0,57}| |{1,-57:g}|", "(g|G) Формат выбирает более короткую запись (f) или (e)", 0.000123);
            Console.WriteLine("|{0,57}| |{1,-57:g}|", "(g) выбирает формат (e)", 0.0000123);
            Console.WriteLine("|{0,57}| |{1,-57:g2}|", "(g2) с точностью 2", 0.0000123);
            Console.WriteLine("---Специальные форматы чисел-------------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,57}| |{1,-57:c}|", "(c|C) Формат валюты", 1234);
            Console.WriteLine("|{0,57}| |{1,-57:c0}|", "(c0) с точностью 0", 1234);
            Console.WriteLine("|{0,57}| |{1,-57:p}|", "(p|P) Формат процентов", 0.12);
            Console.WriteLine("|{0,57}| |{1,-57:p0}|", "(p0) с точностью 0", 0.12);
            Console.WriteLine("|{0,57}| |{1,-57:X}|", "(X) Шестнадцатеричный формат", 11259375);
            Console.WriteLine("|{0,57}| |{1,-57:x7}|", "(x7) строчный регистр, дополняет до 7 '0'", 11259375);
            Console.WriteLine("|{0,57}| |{1,-57:r}|", "(r|R) Формат обратного преобразования", new BigInteger(Int64.MaxValue));
            Console.WriteLine("|{0,57}| |{1,-57}|", "гарантирует обратное преобразование", "");
            Console.WriteLine("|{0,57}| |{1,-57}|", "из string в BigInteger без потери данных", "");
            Console.WriteLine("---Настраиваемые форматы чисел-----------------------------------------------------------------------------------------");
            Console.WriteLine("|{0,57}| |{1,-57:0000.0000}|", "Заместитель цифры или нуля (0000.0000)", 123.456);
            Console.WriteLine("|{0,57}| |{1,-57:00.00}|", "(00.00)", 123.456);
            Console.WriteLine("|{0,57}| |{1,-57:####.####}|", "Заместитель цифры (####.####)", 123.456);
            Console.WriteLine("|{0,57}| |{1,-57:##.##}|", "(##.##)", 123.456);
            Console.WriteLine("|{0,57}| |{1,-57:##.##}|", "(.) Разделитель целой и дробной части", 12.34);
            Console.WriteLine("|{0,57}| |{1,-57:#,###}|", "(,) Разделитель групп", 1234);
            Console.WriteLine("|{0,57}| |{1,-57:##%}|", "(%) Процент", 0.12);
            Console.WriteLine("|{0,57}| |{1,-57:###‰}|", "(‰) Промилле", 0.123);
            Console.WriteLine("|{0,57}| |{1,-57:}|", "Разделитель секций (<##.##>;[-##.##];ноль)", 12.34);
            Console.WriteLine("|{0,57}| |{1,-57:<##.##>;[-##.##];ноль}|", "определяет секции с раздельными строками формата", -12.34);
            Console.WriteLine("|{0,57}| |{1,-57:<##.##>;[-##.##];ноль}|", "для положительных чисел, отрицательных чисел и нуля", 0);
            Console.WriteLine("---Форматы даты и времени----------------------------------------------------------------------------------------------");
            DateTime dateTime = DateTime.Now;
            Console.WriteLine("|{0,57}| |{1,-57:t}|", "(t) Короткий формат времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:T}|", "(T) Полный формат времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:d}|", "(d) Короткий формат даты", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:D}|", "(D) Полный формат даты", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:f}|", "(f) Полный формат даты и короткий формат времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:F}|", "(F) Полный формат даты и полный формат времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:g}|", "(g) Короткий формат даты и короткий формат времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:G}|", "(G) Короткий формат даты и полный формат времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:m}|", "(m|M) Формат дня и месяца", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:y}|", "(y|Y) Формат месяца и года", dateTime);
            Console.WriteLine("---Специальные форматы даты и времени--------------------------------------------------------------------------------");
            Console.WriteLine("|{0,57}| |{1,-57:o}|", "(o|O) Формат обратного преобразования (ISO8601)", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:r}|", "(r|R) Формат обратного преобразования (RFC1123)", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:s}|", "(s) Сортируемый формат даты и времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:u}|", "(u) Универсальный сортируемый формат даты и времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:U}|", "(U) Универсальный полный формат даты и времени", dateTime);
            Console.WriteLine("---Настраиваемые форматы даты и времени--------------------------------------------------------------------------------");
            Console.WriteLine("|{0,57}| |{1,-57:%d}|", "(%d) День месяца от 1 до 31", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:dd}|", "(dd) День месяца от 01 до 31", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:ddd}|", "(ddd) Короткий день недели", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:dddd}|", "(dddd) Полный день недели", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%f}|", "(%f) Десятые доли секунды", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:ff}|", "(ff) Сотые", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:fff}|", "(fff) Тысячные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:ffff}|", "(ffff) Десятитысячные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:fffff}|", "(fffff) Стотысячные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:ffffff}|", "(ffffff) Миллионные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:fffffff}|", "(fffffff) Десятимиллионные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%F}|", "(%F) Десятые доли секунды, 0 - нет вывода", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:FF}|", "(FF) Сотые", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:FFF}|", "(FFF) Тысячные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:FFFF}|", "(FFFF) Десятитысячные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:FFFFF}|", "(FFFFF) Стотысячные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:FFFFFF}|", "(FFFFFF) Миллионные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:FFFFFFF}|", "(FFFFFFF) Десятимиллионные", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%g}|", "(%g|gg) Эра", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%h}|", "(%h) Часы от 1 до 12", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:hh}|", "(hh) Часы от 01 до 12", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%H}|", "(%H) Часы 0 до 23", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:HH}|", "(HH) Часы 00 до 23", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%K}|", "(%K) Выводит часового пояс, если DateTimeKind.Local", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57}|", "выводит Z, если DateTimeKind.Utc", "");
            Console.WriteLine("|{0,57}| |{1,-57}|", "выводит String.Empty, если DateTimeKind.Unspecified", "");
            Console.WriteLine("|{0,57}| |{1,-57:%m}|", "(%m) Минуты от 0 до 59", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:mm}|", "(mm) Минуты от 00 до 59", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%M}|", "(%M) Месяц от 1 до 12", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:MM}|", "(MM) Месяц от 01 до 12", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:MMM}|", "(MMM) Короткий месяц", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:MMMM}|", "(MMMM) Полный месяц", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%s}|", "(%s) Секунды от 0 до 59", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:ss}|", "(ss) Секунды от 00 до 59", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%t}|", "(%t) Первый символ AM/PM (до полудня/после полудня)", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:tt}|", "(tt) Указатель AM/PM", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%y}|", "(%y) Год от 0 до 99", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:yy}|", "(yy) Год от 00 до 99", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:yyy}|", "(yyy) Год дополняет до 3 '0'", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:yyyy}|", "(yyyy) Год дополняет до 4 '0'", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:yyyyy}|", "(yyyyy) Год дополняет до 5 '0'", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:%z}|", "(%z) Часовой сдвиг в формате UTC -12 0 +12", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:zz}|", "(zz) -12 00 +12", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:zzz}|", "(zzz) -00:00", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:hh:mm:ss}|", "(:) Разделитель компонентов времени", dateTime);
            Console.WriteLine("|{0,57}| |{1,-57:dd/MM/yyyy}|", "(/) Разделитель компонентов даты", dateTime);
            Console.WriteLine(@"|{0,57}| |{1,-57:hh\h mm\m ss\s}|", @"(\) Escape-символ", dateTime);
        }
    }
}