using System;

[assembly: CLSCompliant(true)]
namespace AttributedCarLibrary
{
    // Назначить описание с помощью "именованного свойства".
    [Serializable]
    [Vehicle("Мотоцикл", Description = "Харли-Дэвидсон")]
    public class Motorcycle
    { }

    [Serializable]
    [Obsolete("Используйте другую технику")]
    [Vehicle("Лошадь")]
    public class HorseAndBuggy
    { }

    [Vehicle("Дом на колесах")]
    public class Winnebago
    { }
}
