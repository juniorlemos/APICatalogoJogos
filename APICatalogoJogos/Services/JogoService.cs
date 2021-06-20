using APICatalogoJogos.Entities;
using APICatalogoJogos.InputModel;
using APICatalogoJogos.Repository;
using APICatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APICatalogoJogos.Services
{
    public class JogoService : IJogoService
    {

        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }


        public async Task<List<JogoViewModel>> Get(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Get(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {

                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            }
                ).ToList();

        }

        public async Task<JogoViewModel> GetId(Guid id)
        {

            var jogo = await _jogoRepository.GetId(id);

            if (jogo == null)
            {
                return null;
            }
            
            return new JogoViewModel
            {

                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco

            };

        }

       

        public async Task<JogoViewModel> Post(JogoInputModel jogo)
        {
            var novoJogo = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
            await _jogoRepository.Post(novoJogo);
            return new JogoViewModel
            {

                Id = novoJogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco

            };
        }

        public async Task Put(Guid id, JogoInputModel jogo)
        {
           var entidadeJogo = await _jogoRepository.GetId(id);

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _jogoRepository.Put(entidadeJogo);
        }
              public async Task Delete(Guid id)
        {

            await _jogoRepository.Delete(id);


        }

        public void dispose() {
          
                _jogoRepository.Dispose();
        }
        
    }
}
