using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Domain.Models;
using Verificacao_Validacao.Persistence.Context;

namespace Verificacao_Validacao.Persistence.Repository;

public class UsuarioRepository : BaseRepositoy<Usuario>, IUsuario
{
    public UsuarioRepository(DbUsuario context) : base(context)
    {
    }

    public void Atualizar(Guid Id, Usuario usuario)
    {
        var buscarId = _context.Usuarios.Find(Id);
        if (buscarId != null)
        {
            buscarId.Name = usuario.Name;
            buscarId.Email = usuario.Email;
            buscarId.Senha = usuario.Senha;
            buscarId.DataDeCriacao = usuario.DataDeCriacao;

            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Usuario inexistente");
        }
           
    }
}
