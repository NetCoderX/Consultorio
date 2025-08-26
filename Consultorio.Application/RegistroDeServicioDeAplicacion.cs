using Consultorio.Application.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using Consultorio.Application.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using Consultorio.Application.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;

namespace Consultorio.Application
{
    public static class RegistroDeServicioDeAplicacion
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IMediator, MediadorSimple>();
            services.AddScoped<IRequestHandler<ComandoCrearConsultorio, Guid>, CasoDeUsoCrearConsultorio>();
            services.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>, CasoDeUsoObtenerDetalleConsultorio>();


            return services;
        }

    }
}
