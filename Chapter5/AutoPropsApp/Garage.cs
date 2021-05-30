namespace AutoPropsApp
{
    class Garage
    {
        // Скрытое поддерживающее поле установлено в 1
        public int NumberOfCars { get; set; } = 1;
        // Скрытое поддерживающее поле установлено в новый объект Саг
        public Car MyAuto { get; set; } = new Car();

        public Garage() { }
        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
