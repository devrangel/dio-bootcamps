using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
