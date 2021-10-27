using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_WebApi.Domains;

namespace WishList_WebApi.Interfaces
{
    interface IDesejo
    {
        List<Desejo> Listar();

        Desejo BuscarPorId(int IdDesejo);

        void Cadastrar(Desejo novoDesejo);

        void Atualizar(int IdDesejo, Desejo desejoAtualizado);

        void Deletar(int IdDesejo);

    }
}
