using System;
using System.IO;

namespace DirectoryWatcherApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Работа с классом FileSystemWatcher");
            // Установить наблюдаемый каталог (следить только за текстовыми файлами).
            FileSystemWatcher watcher = new FileSystemWatcher("WatchedFolder", "*.txt");
            // Указать тип отслеживаемых изменений.
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Добавить обработчики событии.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;
            // Начать наблюдение за каталогом.
            watcher.EnableRaisingEvents = true;

            // Ожидать от пользователя команду завершения программы.
            Console.WriteLine("Введите Q для завершения программы...");
            while (!Console.ReadLine().Equals("Q", StringComparison.OrdinalIgnoreCase));
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Сообщить о действии изменения, создания или удаления файла.
            Console.WriteLine("Файл: {0} был {1}", e.FullPath, e.ChangeType);
        }
        static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Сообщить о действии переименования файла.
            Console.WriteLine("Файл: {0} переименован в {1}", e.OldFullPath, e.FullPath);
        }
    }
}
