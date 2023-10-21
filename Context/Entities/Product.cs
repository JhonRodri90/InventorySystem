
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Cost { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool State { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int MarkId { get; set; }
        [ForeignKey("MarkId")]
        public Mark Mark { get; set; }
        public int? ParentId { get; set; }
        public virtual Product Parent { get; set; }
    }
}
