using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList_WebApi.Contexts;
using WishList_WebApi.Domains;
using WishList_WebApi.Interfaces;

namespace WishList_WebApi.Repositories
{
    public class DesejoRepository : IDesejo
    {
        WishListContext ctx = new WishListContext();

        public void Atualizar(int IdDesejo, Desejo desejoAtualizado)
        {
            Desejo desejoBuscado = BuscarPorId(IdDesejo);

            if (desejoAtualizado.Descricao != null)
            {
                desejoBuscado.Descricao = desejoAtualizado.Descricao;
            }

            ctx.Desejos.Update(desejoBuscado);

            ctx.SaveChanges();
        }

        public Desejo BuscarPorId(int IdDesejo)
        {
            return ctx.Desejos.FirstOrDefault(e => e.IdDesejo == IdDesejo);
        }

        public void Cadastrar(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);

            ctx.SaveChanges();
        }

        public void Deletar(int IdDesejo)
        {
            Desejo desejoBuscado = BuscarPorId(IdDesejo);

            ctx.Desejos.Remove(desejoBuscado);

            ctx.SaveChanges();
        }

        public List<Desejo> Listar()
        {
            return ctx.Desejos.ToList();
        }
    }
}
