using Consultorio.Application.Interfaces.Repository;

namespace Consultorio.Persistence.Repositorios;
public class RepositorioConsultorio : Repository<Domain.Entities.Consultorio>, IRepositoryConsultorio
{
    public RepositorioConsultorio(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
