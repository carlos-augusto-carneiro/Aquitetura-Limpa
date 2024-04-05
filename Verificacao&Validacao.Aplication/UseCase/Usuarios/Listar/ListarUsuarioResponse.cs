using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verificacao_Validacao.Aplication.UseCase.Usuarios.Listar
{
    public sealed record ListarUsuarioResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime DataDeCriacao { get; set; }
    }
}
