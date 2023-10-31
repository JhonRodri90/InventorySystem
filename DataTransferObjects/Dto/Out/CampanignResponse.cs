namespace DataTransferObjets.Dto.Out
{
    public class CampanignResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string CreatedById { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedById { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
