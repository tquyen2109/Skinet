using System;
using System.Collections.Generic;

namespace Core.Entity.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress, DeliveryMethod deliveryMethod, double subtotal)
        {
           BuyerEmail = buyerEmail;
           ShipToAddress = shipToAddress;
           DeliveryMethod = deliveryMethod;
           OrderItems = orderItems;
           Subtotal = subtotal;
        }
        public Order()
        {
            
        }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public double Subtotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        public double GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}