namespace Consultorio.Application.Utilidades.Mediador
{
    public interface IMediator 
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
