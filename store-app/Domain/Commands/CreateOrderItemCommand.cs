using Domain.Commands.Interfaces;
using System;

namespace Domain.Commands
{
    public class CreateOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
        public bool Valid { get; set; }

        public CreateOrderItemCommand()
        {
        }

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Valid = Validate();
        }

        public bool Validate()
        {
            if (Product.ToString().Length != 32)
                return false;

            if (Quantity < 0)
                return false;

            return true;
        }
    }
}
