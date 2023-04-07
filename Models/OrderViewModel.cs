namespace EggSplorer.Models
{
    public class OrderViewModel
    {
        public List<Products> Products { get; set; } = null!;
        public OrderDetails OrderDetails { get; set; } = null!;
    }

}
