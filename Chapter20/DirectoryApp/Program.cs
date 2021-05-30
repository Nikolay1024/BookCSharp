using System;
using System.IO;
using System.Linq;

namespace DirectoryApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Работа с типом DirectoryInfo и Directory");
            CreateDirAndDisplayDirInfo();
            DisplayImageFilesInfo();
            CreateSubdir();
            DeleteDirs();
        }

        static void CreateDirAndDisplayDirInfo()
        {
            // Привязаться к несуществующему каталогу в каталоге приложения.
            DirectoryInfo dir = new DirectoryInfo("Directory");
            dir.Create();
            Console.WriteLine("Полное имя: {0}", dir.FullName);
            Console.WriteLine("Имя каталога: {0}", dir.Name);
            Console.WriteLine("Родительский каталог: {0}", dir.Parent);
            Console.WriteLine("Время создания: {0}", dir.CreationTime);
            Console.WriteLine("Атрибуты: {0}", dir.Attributes);
            Console.WriteLine("Корневой каталог: {0}", dir.Root);
            Console.ReadLine();
        }
        static void DisplayImageFilesInfo()
        {
            DirectoryInfo dir = new DirectoryInfo("Images");
            // Получить все файлы с расширением (*.jpg) в каталоге и подкаталогах.
            FileInfo[] images = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            Console.WriteLine("Найдено файлов (*.jpg): {0}", images.Length);
            // Вывести информацию о каждом файле.
            foreach (FileInfo image in images)
            {
                Console.WriteLine("Имя файла: {0}", image.Name);
                Console.WriteLine("Размер: {0}", image.Length);
                Console.WriteLine("Время создания: {0}", image.CreationTime);
                Console.WriteLine("Атрибуты: {0:G}", image.Attributes);
            }
            Console.ReadLine();
        }
        static void CreateSubdir()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            // Создать .\Subdir\Data в каталоге приложения.
            DirectoryInfo subdir = dir.CreateSubdirectory(@"Subdir\Data");
            Console.WriteLine("Подкаталоги успешно созданы: {0}", subdir.FullName);
            Console.ReadLine();
        }
        static void DeleteDirs()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Список логических устройств на компьютере: {0}", string.Join("; ", drives));
            Console.Write("Введите D для удаления ранее созданных каталогов: ");
            string answer = Console.ReadLine();
            if (!answer.Equals("D", StringComparison.OrdinalIgnoreCase))
                return;
            try
            {
                Directory.Delete("Directory");
                // Второй параметр указывает, нужно ли удалять вложенные подкаталоги.
                Directory.Delete("Subdir", true);
                Console.WriteLine("Каталоги успешно удалены");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}