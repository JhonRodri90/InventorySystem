using Context.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTransferObjets.Dto.In
{
    public class CampanignRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CreatedById { get; set; } = "835448a8-96fb-4197-9530-91dec188ab24";//string.Empty;
        public string UpdatedById { get; set; } = "835448a8-96fb-4197-9530-91dec188ab24"; // string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
