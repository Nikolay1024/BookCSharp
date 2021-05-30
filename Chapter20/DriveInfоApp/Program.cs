using System;
using System.IO;

namespace DriveInfоApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=> Работа с типом DriveInfo");
            // Получить информацию обо всех устройствах.
            DriveInfo[] drives = DriveInfo.GetDrives();
            // Вывести сведения об устройствах.
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Имя диска: {0}", drive.Name);
                Console.WriteLine("Тип диска: {0}", drive.DriveType);
                // Проверить, смонтировано ли устройство.
                if (drive.IsReady)
                {
                    Console.WriteLine("Свободное пространство: {0} (Б)", drive.TotalFreeSpace);
                    Console.WriteLine("Формат устройства: {0}", drive.DriveFormat);
                    Console.WriteLine("Метка тома: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
