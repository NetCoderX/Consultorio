using Consultorio.Application.Excepciones;
using System.Net;
using System.Text.Json;

namespace Consultorio.API.Middlewares;

public class ManejadorExcepcionesMiddleware
{
    private readonly RequestDelegate _next;
    public ManejadorExcepcionesMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ManejarExcepcion(context, ex);
        }
    }

    private Task ManejarExcepcion(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var resultado = string.Empty;

        switch(exception)
        {
            case ExcepcionNoEncontrado:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case ExcepcionDeValidacion excepcionValidacion:
                httpStatusCode = HttpStatusCode.BadRequest;
                resultado = JsonSerializer.Serialize(excepcionValidacion.ErroresDeValidacion);
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(resultado);
    }        
}
public static class ManejadorExcepcionesMiddlewareExtensions
{
    public static IApplicationBuilder UseManejadorEcepciones(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ManejadorExcepcionesMiddleware>();
    }
}
