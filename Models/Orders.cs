using System.Collections.Generic;
using Vodovoz.Exceptions;

namespace Vodovoz.Models
{
    internal class Orders
    {
        private readonly List<Order> _orders;

        public Orders()
        {
            _orders = new List<Order>();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public void AddOrder(Order incomingOrder)
        {
            foreach(var existingOrder in _orders)
            {
                if (existingOrder.Id == incomingOrder.Id)
                {
                    throw new OrderConflictException(existingOrder, incomingOrder);
                }
            }

            _orders.Add(incomingOrder);
        }
    }
}
