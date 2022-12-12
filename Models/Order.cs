using System.Collections.Generic;
using Vodovoz.Exceptions;

namespace Vodovoz.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public StaffMember StaffMember { get; set; }

        public Order(int id, List<Product> products, StaffMember staffMember)
        {
            Id = id;
            Products = products;
            StaffMember = staffMember;
        }

        public void AddProduct(Product incomingProduct)
        {
            Products.Add(incomingProduct);
        }
    }
}
