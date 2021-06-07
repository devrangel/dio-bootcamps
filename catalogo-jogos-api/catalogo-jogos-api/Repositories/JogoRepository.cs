using catalogo_jogos_api.Entities;
using catalogo_jogos_api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_jogos_api.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            { Guid.Parse("11111111-1111-1111-1111-111111111111"), new Jogo { Id = Guid.Parse("11111111-1111-1111-1111-111111111111") , Nome = "Fifa 21", Produtora = "EA", Preco = 200 } },
            { Guid.Parse("22222222-2222-2222-2222-222222222222"), new Jogo { Id = Guid.Parse("22222222-2222-2222-2222-222222222222") , Nome = "Fifa 20", Produtora = "EA", Preco = 190 } },
            { Guid.Parse("33333333-3333-3333-3333-333333333333"), new Jogo { Id = Guid.Parse("33333333-3333-3333-3333-333333333333") , Nome = "Fifa 19", Produtora = "EA", Preco = 180 } },
            { Guid.Parse("44444444-4444-4444-4444-444444444444"), new Jogo { Id = Guid.Parse("44444444-4444-4444-4444-444444444444") , Nome = "Fifa 18", Produtora = "EA", Preco = 170 } },
            { Guid.Parse("55555555-5555-5555-5555-555555555555"), new Jogo { Id = Guid.Parse("55555555-5555-5555-5555-555555555555") , Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80 } },
            { Guid.Parse("66666666-6666-6666-6666-666666666666"), new Jogo { Id = Guid.Parse("66666666-6666-6666-6666-666666666666") , Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 190 } },
        };
        
        public Task<List<Jogo>> Get(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }
        
        public Task<Jogo> GetById(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }
        
        public Task<List<Jogo>> GetByName(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }
        
        public Task Post(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }
        
        public Task Put(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar conexão com o banco
        }





    }
}
