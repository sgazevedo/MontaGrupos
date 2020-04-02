using Microsoft.Extensions.Configuration;
using System.IO;

namespace MontaGrupos.Infra.Sistema
{
    public static class Configuracoes
    {
        private static readonly IConfigurationRoot configuracoes = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        public static void Definir(string key, object instance)
        {
            configuracoes.Bind(key, instance);
        }
    }
}