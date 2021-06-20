using APICatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoJogos.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid,Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("81a130d2-502f-4c13-a376-63edeb000e9f"), new Jogo{ Id = Guid.Parse("81a130d2-502f-4c13-a376-63edeb000e9f"), Nome="Futebol" , Produtora="EA",Preco=200   } },
            {Guid.Parse("e1ab63c4-89f3-4002-95ad-8441ff41800a"), new Jogo{ Id = Guid.Parse("e1ab63c4-89f3-4002-95ad-8441ff41800a"), Nome="Tekken" , Produtora="EA",Preco=200   } },
            {Guid.Parse("fd93f054-ff87-40d4-8c26-95a543f9689d"), new Jogo{ Id = Guid.Parse("fd93f054-ff87-40d4-8c26-95a543f9689d"), Nome="Free Fire" , Produtora="EA",Preco=200   } },
            {Guid.Parse("e1bfcaf8-0bd6-4e72-9751-d59f6f7a3617"), new Jogo{ Id = Guid.Parse("e1bfcaf8-0bd6-4e72-9751-d59f6f7a3617"), Nome="GTA" , Produtora="EA",Preco=200   } },
            {Guid.Parse("fed74001-0f8c-401b-9259-07d71679b75b"), new Jogo{ Id = Guid.Parse("fed74001-0f8c-401b-9259-07d71679b75b"), Nome="God Of War" , Produtora="EA",Preco=200   } },
            {Guid.Parse("e5d10f4d-a7e8-4742-8771-18daca5c4db2"), new Jogo{ Id = Guid.Parse("e5d10f4d-a7e8-4742-8771-18daca5c4db2"), Nome="Metal GEAR" , Produtora="EA",Preco=200   } }


        };


        public Task<List<Jogo>> Get(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> GetId(Guid id)
        {
            if (!jogos.ContainsKey(id))
            {
                return null;
            }
            return Task.FromResult(jogos[id]);

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

        }

      
    }
}

