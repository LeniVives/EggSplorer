namespace EggSplorer.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime? OrderFulfilled { get; set; }

        public int UserID { get; set; }

        public Users User { get; set; } = null!;

        public ICollection<OrderDetails> OrderDetail { get; set; } = null!;
    }
}
