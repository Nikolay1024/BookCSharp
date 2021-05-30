namespace CustomInterface
{
    // Все члены интерфейса неявно открытые и абстрактные
    public interface IPointy
    {
        // Свойство
        // byte Points { get; set; }

        // Свойство только для записи
        // byte Points { set; }

        // Свойство только для чтения
        byte Points { get; }

        // Метод
        // byte GetNumberOfPoints();
    }
}
