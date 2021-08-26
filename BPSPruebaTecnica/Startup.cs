using Aplicacion.Estudiante;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistencia.Entidad;
using MediatR;
using BPSPruebaTecnica.Middleware;
using System.Text.Json.Serialization;
using Aplicacion.Nota;
using Aplicacion.Profesor;
using Aplicacion.Mapper;
using AutoMapper;
using FluentValidation.AspNetCore;

namespace BPSPruebaTecnica
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("corsApp", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddDbContext<BPSContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddOptions();
            services.AddMediatR(typeof(GetEstudiantes.Manejador).Assembly);
            services.AddMediatR(typeof(GetNotas.Manejador).Assembly);
            services.AddMediatR(typeof(GetProfesores.Manejador).Assembly);

            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<PostNota.CrearNota>())
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<PutNota.ActualizarNota>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BPSPruebaTecnica", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("corsApp");
            if (env.IsDevelopment())
            {
                app.UseMiddleware<ValidacionesErrorMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BPSPruebaTecnica v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
