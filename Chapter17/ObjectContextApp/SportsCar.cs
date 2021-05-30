using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObjectContextApp
{
    // Класс SportsCar не имеет никаких специальных контекстных потребностей
    // и будет загружаться в стандартный контекст домена приложения.
    class SportsCar
    {
        public SportsCar()
        {
            // Получить информацию о контексте и вывести идентификатор контекста.
            Context context = Thread.CurrentContext;
            Console.WriteLine("Объект {0} в контексте: {1}", this, context.ContextID);
            foreach (IContextProperty contextProp in context.ContextProperties)
                Console.WriteLine("-> Контекстное свойство: {0}", contextProp.Name);
        }
    }

    // Класс SportsCarThreadSafe требует загрузки
    // в синхронизированный контекст домена приложения.
    [Synchronization]
    class SportsCarThreadSafe : ContextBoundObject
    {
        public SportsCarThreadSafe()
        {
            // Получить информацию о контексте и вывести идентификатор контекста.
            Context context = Thread.CurrentContext;
            Console.WriteLine("Объект {0} в контексте: {1}", this, context.ContextID);
            foreach (IContextProperty contextProp in context.ContextProperties)
                Console.WriteLine("-> Контекстное свойство: {0}", contextProp.Name);
        }
    }
}
