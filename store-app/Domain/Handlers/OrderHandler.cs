using Domain.Commands;
using Domain.Commands.Interfaces;
using Domain.Entities;
using Domain.Handlers.Interfaces;
using Domain.Repositories.Interfaces;
using Domain.Utils;
using System.Linq;

namespace Domain.Handlers
{
    public class OrderHandler : IHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeRepository _deliveryFeeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(
            ICustomerRepository customerRepository, 
            IDeliveryFeeRepository deliveryFeeRepository, 
            IDiscountRepository discountRepository, 
            IProductRepository productRepository, 
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeRepository = deliveryFeeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if (command.Valid == false)
                return new GenericCommandResult(false, "Pedido Inválido", null);

            var customer = _customerRepository.Get(command.Customer);

            var deliveryFee = _deliveryFeeRepository.Get(command.ZipCode);

            var discount = _discountRepository.Get(command.PromoCode);

            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();
            var order = new Order(customer, deliveryFee, discount);

            foreach(var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product, item.Quantity);
            }

            _orderRepository.Save(order);
            return new GenericCommandResult(true, $"Pedido {order.Number} gerado com sucesso", order);
        }
    }
}
