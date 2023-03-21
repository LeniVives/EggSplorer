namespace EggSplorer.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Orders Order { get; set; } = null!;

        public int ProductId { get; set; }

        public Products Product { get; set; } = null!;
    }
}
