namespace AutoLotDataAccessLayer.Models
{
    public partial class Order
    {
        public override string ToString()
        {
            return $"OrderId:{ Id }; CustomerId:{ CustomerId }; CarId:{ CarId };";
        }
    }
}
