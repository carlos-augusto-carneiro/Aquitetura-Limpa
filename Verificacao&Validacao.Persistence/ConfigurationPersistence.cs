using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verificacao_Validacao.Domain.Interfaces;
using Verificacao_Validacao.Persistence.Context;
using Verificacao_Validacao.Persistence.Repository;

namespace Verificacao_Validacao.Persistence;

public static class ConfigurationPersistence
{
    public static void ConfigurationPersistenceApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySql");
        services.AddDbContext<DbUsuario>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUsuario, UsuarioRepository>();
    }
}
