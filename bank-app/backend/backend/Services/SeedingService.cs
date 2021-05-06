using backend.Models;
using System.Linq;

namespace backend.Data
{
    public class SeedingService
    {
        private DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Account.Any())
            {
                return;
            }

            Account c1 = new Account("Pedro", "Física", 5000);
            Account c2 = new Account("Antonio", "Física", 3000);
            Account c3 = new Account("Gabriela", "Jurídica", 4000);
            Account c4 = new Account("Maria", "Física", 6250);
            Account c5 = new Account("Marcos", "Jurídica", 10000);
            Account c6 = new Account("Julia", "Física", 2030);

            _context.Account.AddRange(c1, c2, c3, c4, c5, c6);

            _context.SaveChanges();
        }
    }
}
