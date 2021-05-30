using System;

namespace ApplyingAttributes
{
    // Этот класс может быть сохранен на диске.
    [Serializable]
    public class Motorcycle
    {
        // Однако это поле сохраняться не будет.
        [NonSerialized]
        float weightOfCurrentPassengers;
        // Эти поля остаются сериализируемыми.
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}
