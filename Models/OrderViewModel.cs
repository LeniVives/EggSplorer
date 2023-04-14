namespace EggSplorer.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderPlaced { get; set; }
        public string Username { get; set; }
        public decimal OrderTotal { get; set; }
        public List<OrderDetailViewModel> OrderDetailViewModels {get; set;}
    }

}
