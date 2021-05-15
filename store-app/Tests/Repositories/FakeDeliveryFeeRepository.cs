using Domain.Repositories.Interfaces;

namespace Tests.Repositories
{
    public class FakeDeliveryFeeRepository : IDeliveryFeeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10m;
        }
    }
}
