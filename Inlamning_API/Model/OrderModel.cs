namespace Inlamning_API.Model
{
    public class OrderModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double OrderTime { get; set; }
        public string OrderStatus { get; set; }
        public string ProductsOrder { get; set; }
        public int ProductQuantity { get; set; }

       
    }

}
