namespace AutoLotConsoleApp.EntityFramework
{
    public partial class Car
    {
        public Car(string make, string color, string name) : base()
        {
            Make = make;
            Color = color;
            Name = name;
        }

        public override string ToString()
        {
            // Поскольку столбец Name может быть пустым, предоставить стандартное имя NoName.
            return $"Id:{ CarId }; Name:{ Name ?? "NoName" }; Color:{ Color }; Make:{ Make };";
        }
    }
}
