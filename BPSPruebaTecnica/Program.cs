using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistencia.Entidad;
using System;

namespace BPSPruebaTecnica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostServer = CreateHostBuilder(args).Build();
            using (var ambiente = hostServer.Services.CreateScope())
            {
                var services = ambiente.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BPSContext>();
                    context.Database.Migrate();
                    DbInicializador.Inicializador(context);

                }
                catch (Exception e)
                {
                    var logging = services.GetRequiredService<ILogger<Program>>();
                    logging.LogError(e, "Ha ocurrido un error en la migracion");
                }

            };

            hostServer.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
