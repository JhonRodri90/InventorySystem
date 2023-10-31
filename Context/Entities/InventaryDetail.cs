using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Entities
{
    public class InventaryDetail
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        public int InventaryId { get; set; }

        [ForeignKey("InventaryId")]
        public Inventary Inventary { get; set; }

        //[Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //[Required]
        public int StockPrevious { get; set; }

        //[Required]
        public int Amount { get; set; }

    }
}