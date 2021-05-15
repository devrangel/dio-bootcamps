using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}
