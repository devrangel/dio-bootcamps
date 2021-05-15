using Domain.Commands.Interfaces;
using System.Collections.Generic;

namespace Domain.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public string Customer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public bool Valid { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }

        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
            Valid = Validate();
        }

        public bool Validate()
        {
            if (Customer.Length != 11)
                return false;

            if (ZipCode.Length != 8)
                return false;

            return true;
        }
    }
}
