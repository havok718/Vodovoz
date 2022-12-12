using System;
using Vodovoz.Models;

namespace Vodovoz.Exceptions
{
    internal class OrderConflictException : Exception
    {
        public Order ExistingOrder { get; }
        public Order IncomingOrder { get; }

        public OrderConflictException(Order existingOrder, Order incomingOrder)
        {
            ExistingOrder = existingOrder;
            IncomingOrder = incomingOrder;
        }

        public OrderConflictException(string? message, Order existingOrder, Order incomingOrder) : base(message)
        {
            ExistingOrder = existingOrder;
            IncomingOrder = incomingOrder;
        }

        public OrderConflictException(string? message, Exception? innerException, Order existingOrder, Order incomingOrder) : base(message, innerException)
        {
            ExistingOrder = existingOrder;
            IncomingOrder = incomingOrder;
        }
    }
}
