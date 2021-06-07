using catalogo_jogos_api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catalogo_jogos_api.Repositories.Interfaces
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> Get(int pagina, int quantidade);
        Task<List<Jogo>> GetByName(string nome, string produtora);
        Task<Jogo> GetById(Guid id);
        Task Post(Jogo jogo);
        Task Put(Jogo jogo);
        Task Delete(Guid id);
    }
}
