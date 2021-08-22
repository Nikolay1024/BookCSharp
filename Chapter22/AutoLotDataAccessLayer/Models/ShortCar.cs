namespace AutoLotDataAccessLayer.Models
{
    class ShortCar
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public override string ToString() => $"CarId:{ CarId }; Make:{ Make };";
    }
}
