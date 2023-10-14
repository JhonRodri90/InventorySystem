﻿namespace DataTransferObjets.Dto.Out
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool State { get; set; }
    }
}
