using System.ComponentModel.DataAnnotations.Schema;

namespace EggSplorer.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(6,2)")]
        public decimal ProductPrice { get; set; }
    }
}
