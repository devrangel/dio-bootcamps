using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Tests.Repositories
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public Customer Get(string document)
        {
            if (document == "12345678911")
                return new Customer("testeCustomer", "customer@teste.com");

            return null;
        }
    }
}
