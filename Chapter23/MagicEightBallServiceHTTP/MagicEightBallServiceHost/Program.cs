using MagicEightBallServiceLib;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MagicEightBallServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Хостинг службы WCF");
            using (var serviceHost = new ServiceHost(typeof(MagicEightBallService)))
            {
                // Открыть хост и начать прослушивание входящих сообщений.
                serviceHost.Open();
                DisplayHostInfo(serviceHost);
                Console.WriteLine("Служба готова к работе.");
                Console.WriteLine("Нажмите Enter для остановки службы.");
                Console.ReadLine();
            }
        }

        static void DisplayHostInfo(ServiceHost serviceHost)
        {
            Console.WriteLine();
            Console.WriteLine("-> Инфо о хосте");
            foreach (ServiceEndpoint serviceEndpoint in serviceHost.Description.Endpoints)
            {
                Console.WriteLine("Адрес: {0}", serviceEndpoint.Address);
                Console.WriteLine("Привязка: {0}", serviceEndpoint.Binding.Name);
                Console.WriteLine("Контракт: {0}", serviceEndpoint.Contract.Name);
                Console.WriteLine();
            }
        }
    }
}
