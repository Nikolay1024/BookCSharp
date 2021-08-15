namespace AutoLotConsoleApp.EntityFramework
{
    public partial class Order
    {
        public override string ToString()
        {
            return $"OrderId:{ OrderId }; CustomerId:{ CustomerId }; CarId:{ CarId };";
        }
    }
}
