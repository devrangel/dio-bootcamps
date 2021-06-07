using catalogo_jogos_api.InputModel;
using catalogo_jogos_api.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace catalogo_jogos_api.Services.Interfaces
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Get(int pagina, int quantidade);
        Task<JogoViewModel> GetById(Guid id);
        Task<JogoViewModel> Post(JogoInputModel jogo);
        Task Put(Guid id, JogoInputModel jogo);
        Task Patch(Guid id, double preco);
        Task Delete(Guid id);
    }
}
