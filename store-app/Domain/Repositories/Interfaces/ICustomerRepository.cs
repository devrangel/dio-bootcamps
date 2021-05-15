using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer Get(string document);
    }
}
