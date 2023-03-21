namespace EggSplorer.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime? OrderFulfilled { get; set; }

        public int CustomerID { get; set; }

        public Customers Customer { get; set; } = null!;

        public ICollection<OrderDetails> OrderDetail { get; set; } = null!;
    }
}
