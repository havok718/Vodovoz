namespace Vodovoz.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public int StaffMember { get; set; }

        public Order(int id, int productId, string productName, int count, int staffMember)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            Count = count;
            StaffMember = staffMember;
        }
    }
}
