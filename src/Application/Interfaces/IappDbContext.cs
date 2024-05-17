using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IappDbContext
{
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public Task<int> SaveChangesAsync(CancellationToken ct = default);
}