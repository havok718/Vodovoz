﻿namespace Vodovoz.DTOs
{
    internal class OrderDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Count { get; set; }
        public int StaffMemberId { get; set; }
    }
}
