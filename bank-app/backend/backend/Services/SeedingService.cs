using backend.Models;
using backend.Models.Enums;
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

            Account c1 = new Account("Pedro", TipoConta.PessoaFisica, 5000, 300);
            Account c2 = new Account("Antonio", TipoConta.PessoaFisica, 3000, 150);
            Account c3 = new Account("Gabriela", TipoConta.PessoaJuridica, 4000, 200);
            Account c4 = new Account("Maria", TipoConta.PessoaFisica, 6250, 423);
            Account c5 = new Account("Marcos", TipoConta.PessoaJuridica, 10000, 1250);
            Account c6 = new Account("Julia", TipoConta.PessoaFisica, 2030, 150);

            _context.Account.AddRange(c1, c2, c3, c4, c5, c6);

            _context.SaveChanges();
        }
    }
}
