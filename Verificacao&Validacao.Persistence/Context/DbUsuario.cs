using Microsoft.EntityFrameworkCore;
using Verificacao_Validacao.Domain.Models;
using Verificacao_Validacao.Persistence.ModelsMapping;

namespace Verificacao_Validacao.Persistence.Context
{
    public class DbUsuario : DbContext
    {
        public DbUsuario(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }
    }
}
