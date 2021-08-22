namespace AutoLotDataAccessLayer.Models
{
    public partial class Order
    {
        public override string ToString()
        {
            return $"OrderId:{ OrderId }; CustomerId:{ CustomerId }; CarId:{ CarId };";
        }
    }
}
