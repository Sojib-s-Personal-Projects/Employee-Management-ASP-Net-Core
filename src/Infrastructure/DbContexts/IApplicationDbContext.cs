using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
       DbSet<Worker> Workers { get; set; }
    }
}