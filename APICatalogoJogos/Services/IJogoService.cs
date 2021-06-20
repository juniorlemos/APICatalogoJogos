using APICatalogoJogos.InputModel;
using APICatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APICatalogoJogos.Services
{
    public interface IJogoService
    {
        Task <List<JogoViewModel>> Get( int pagina , int quantidade);
        Task<JogoViewModel> GetId(Guid id);
        Task Delete(Guid id);
        Task<JogoViewModel>Post(JogoInputModel jogo);
        Task Put(Guid id,JogoInputModel jogo );
       

    }
}
