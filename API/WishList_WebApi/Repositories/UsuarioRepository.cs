using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_WebApi.Contexts;
using WishList_WebApi.Domains;
using WishList_WebApi.Interfaces;

namespace WishList_WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishListContext ctx = new WishListContext();

        public void Atualizar(int IdUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(IdUsuario);

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int IdUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == IdUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int IdUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(IdUsuario);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

    }
}
