using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Adicionar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Atualizar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Deletar;
using Verificacao_Validacao.Aplication.UseCase.Usuarios.Listar;

namespace Verificacao_Validacao.Aplication.Service;

public static class ServicesExtensions
{
    public static void ConfigurationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(typeof(AdicionaUsuarioMap));
        services.AddAutoMapper(typeof(AtualizarUsuarioMap));
        services.AddAutoMapper(typeof(DeletarUsuarioMap));
        services.AddAutoMapper(typeof(ListarUsuarioMap));
    }
}
