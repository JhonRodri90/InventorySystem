using System.ComponentModel.DataAnnotations;

namespace Context.Entities
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; }

    }
}
