using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verificacao_Validacao.Domain.Models;

namespace Verificacao_Validacao.Persistence.ModelsMapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).
                IsRequired().
                ValueGeneratedOnAdd().
                HasColumnName("Id").
                HasColumnOrder(1);
            builder.Property(x => x.Name).
                IsRequired().
                HasColumnName("Nome").
                HasColumnOrder(2).
                HasMaxLength(64);
            builder.Property(x => x.Email).
                IsRequired().
                HasColumnName("Email").
                HasColumnOrder(3).
                HasMaxLength(128);
            builder.Property(x => x.Senha).
                IsRequired().
                HasColumnName("Senha").
                HasColumnOrder(4);
        }
    }
}
