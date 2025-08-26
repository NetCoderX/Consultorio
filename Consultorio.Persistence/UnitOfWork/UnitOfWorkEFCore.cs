using Consultorio.Application.Interfaces.Persistencia;

namespace Consultorio.Persistence.UnitOfWork;
public class UnitOfWorkEFCore : IUnitOfWork
{
    private readonly AppDbContext _context;
    public UnitOfWorkEFCore(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    public async Task Persistir()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Reversar()
    {
        await Task.CompletedTask;   
    }
}
