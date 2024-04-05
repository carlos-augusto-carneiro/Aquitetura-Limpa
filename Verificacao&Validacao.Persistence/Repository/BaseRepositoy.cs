using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Domain.Models;
using Verificacao_Validacao.Persistence.Context;

namespace Verificacao_Validacao.Persistence.Repository
{
    public class BaseRepositoy<T> : IBase<T> where T : ClassBase
    {
        protected readonly DbUsuario _context;

        public BaseRepositoy(DbUsuario context)
        {
            _context = context;
        }

        public void Cadastrar(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Deletar(Guid Id)
        {
            var buscarId = _context.Set<T>().FirstOrDefault(x=>x.Id.Equals(Id));
            if(buscarId != null)
            {
                _context.Set<T>().Remove(buscarId);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Usuario inexistente");
            }

        }

        public List<T> Listar()
        {
            return _context.Set<T>().ToList();
        }
    }
}
