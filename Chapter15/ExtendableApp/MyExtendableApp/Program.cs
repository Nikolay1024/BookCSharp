using CommonSnappableTypes;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MyExtendableApp
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("=> Построение расширяемого консольного приложения");
            do
            {
                Console.WriteLine("Загрузить оснастку? [Y,N]");
                string answer = Console.ReadLine();
                if (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    break;
                // Попытаться отобразить тип.
                try
                {
                    LoadSnapIn();
                }
                catch
                {
                    Console.WriteLine("Найти оснастку не удалось");
                }
            } while (true);
        }
        
        static void LoadSnapIn()
        {
            // Предоставить пользователю возможность выбора сборки для загрузки.
            OpenFileDialog dialog = new OpenFileDialog
            {
                // Установить в качестве начального каталога путь к текущему проекту.
                InitialDirectory = Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location),
                Filter = "Assemblies (*.dll)|*.dll|All files (*.*)|*.*",
            };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                Console.WriteLine("Пользователь закрыл диалоговое окно.");
                return;
            }
            if (dialog.FileName.Contains("CommonSnappableTypes"))
                Console.WriteLine("В CommonSnappableTypes нет оснасток!");
            else if (!LoadExternalModule(dialog.FileName))
                Console.WriteLine("Интерфейс IAppFunctionality не реализован!");
        }
        static bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly asmSnapIn;
            try
            {
                // Динамически загрузить выбранную сборку.
                asmSnapIn = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке оснастки: {0}", ex.Message);
                return foundSnapIn;
            }
            // Получить все совместимые c IAppFunctionality классы в сборке.
            var classTypes = from type in asmSnapIn.GetTypes()
                             where type.IsClass
                                   && (type.GetInterface("IAppFunctionality") != null)
                             select type;
            // Создать объект и вызвать метод DoIt().
            foreach (Type type in classTypes)
            {
                foundSnapIn = true;
                // Использовать позднее связывание для создания экземпляра типа.
                IAppFunctionality iAppFunc =
                    (IAppFunctionality)asmSnapIn.CreateInstance(type.FullName, true);
                iAppFunc?.DoIt();
                // Отобразить информацию о компании.
                DisplayCompanyData(type);
            }
            return foundSnapIn;
        }
        static void DisplayCompanyData(Type type)
        {
            // Получить данные [CompanyInfo].
            var compInfo = from ci in type.GetCustomAttributes(false)
                           where ci is CompanyInfoAttribute
                           select ci;
            // Отобразить данные.
            foreach (CompanyInfoAttribute c in compInfo)
                Console.WriteLine("Информацию о компании {0} можно найти на сайте {1}.",
                    c.CompanyName, c.CompanyUrl);
        }
    }
}
