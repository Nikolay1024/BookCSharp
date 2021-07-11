namespace AutoLotDataAccessLayer.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Name { get; set; }

        public Car() { }
        public Car(string color, string make, string name)
        {
            Color = color;
            Make = make;
            Name = name;
        }
        public override string ToString()
            => $"CarId={CarId}; Color={Color}; Make={Make}; Name={Name};";
    }
}
