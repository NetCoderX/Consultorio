﻿using Consultorio.Application.Interfaces.Persistencia;
using Consultorio.Application.Interfaces.Repository;
using Consultorio.Persistence.Repositorios;
using Consultorio.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consultorio.Persistence;
public static class RegistroDeServiciosDePersistencia
{

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IRepositoryConsultorio, RepositorioConsultorio>();
        services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();
        return services;
    }
}
