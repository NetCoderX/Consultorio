namespace Consultorio.Application.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> ObtenerPorId(Guid id);
        Task<IEnumerable<T>> ObtenerTodos();
        Task<T> Agregar(T entidad);
        Task Actualizar(T entidad);
        Task Eliminar(T entidad);

    }
}
