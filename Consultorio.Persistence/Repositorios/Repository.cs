using Consultorio.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Persistence.Repositorios;
public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    public Task Actualizar(T entidad)
    {
        _context.Update(entidad);
        return Task.CompletedTask;
    }

    public Task<T> Agregar(T entidad)
    {
       _context.Add(entidad);
        return Task.FromResult(entidad);
    }

    public Task Eliminar(T entidad)
    {
        _context.Remove(entidad);   
        return Task.CompletedTask;
    }

    public async Task<T?> ObtenerPorId(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> ObtenerTodos()
    {
        return await _context.Set<T>().ToListAsync();
    }
}
