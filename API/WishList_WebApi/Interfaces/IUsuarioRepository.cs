using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_WebApi.Domains;

namespace WishList_WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int IdUsuario);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int IdUsuario, Usuario usuarioAtualizado);

        void Deletar(int IdUsuario);

    }
}
