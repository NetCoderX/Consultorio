namespace Consultorio.Application.Interfaces.Persistencia
{
    public interface IUnitOfWork
    {
        Task Persistir();
        Task Reversar();
    }
}
