using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    class Order : Entity
    {
        public Costumer Costumer { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public Discount Discount { get; private set; }
        public EOrderStatus Status { get; private set; }

        public Order(Costumer costumer, decimal deliveryFee, Discount discount)
        {
            Costumer = costumer;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatus.WaitingPayment;
            DeliveryFee = deliveryFee;
            Discount = discount;
            Items = new List<OrderItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            // ------
            // Diminuir o uso dos if's com design by context
            // Externalizar em métodos separados
            if (product == null)
                return;

            if (quantity < 0)
                return;
            // ------

            OrderItem item = new OrderItem(product, quantity);
            Items.Add(item);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (OrderItem item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFee;
            total -= Discount != null ? Discount.Value() : 0;

            return total;
        }

        public void Pay(decimal amount)
        {
            if (amount == Total())
            {
                this.Status = EOrderStatus.WaitingDelivery;
            }
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }
    }
}
