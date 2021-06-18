using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogoJogos.Entities;


namespace APICatalogoJogos.Repository
{
  public  interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> Get(int pagina, int quantidade);
        Task<Jogo> GetId(Guid id);
        Task Delete(Guid id);
        Task<Jogo> Post(Jogo jogo);
        Task Put(Jogo jogo);
      
    }
}
