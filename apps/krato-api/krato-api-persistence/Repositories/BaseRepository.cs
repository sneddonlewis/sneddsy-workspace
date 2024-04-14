
using Microsoft.EntityFrameworkCore;
using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Contracts.Persistence;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiPersistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly KratoDbContext _dbContext;

    public BaseRepository(KratoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
}