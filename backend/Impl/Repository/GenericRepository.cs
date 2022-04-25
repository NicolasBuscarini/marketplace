using MarketPlace.Infrastructure.Data.Context;
using MarketPlace.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Impl.Repository;

public class GenericRepository<T, T_KEY> : IGenericRepository<T, T_KEY> where T : class where T_KEY : struct
{
    private readonly MySQLContext _context;

    protected GenericRepository(MySQLContext context)
    {
        _context = context;
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        var ret = await _context.Set<T>().AddAsync(entity);

        await _context.SaveChangesAsync();

        ret.State = EntityState.Detached;

        return ret.Entity;
    }

    public virtual async Task<int> UpdateAsync(T entity)
    {
        var entry = _context.Entry(entity);

        if (entry != null)
        {
            entry.State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        throw new KeyNotFoundException("Entidade não encontrada");
    }

    public virtual async Task<int> InsertOrUpdateAsync(T entity)
    {
        _context.Update(entity);
        return await _context.SaveChangesAsync();

    }

    public virtual async Task<bool> DeleteAsync(T entity)
    {
        var entry = _context.Entry(entity);

        if (entry != null)
        {
            entry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return true;
        }

        throw new KeyNotFoundException("Entidade não encontrada");
    }
    public virtual T GetById(T_KEY id)
    {
        return _context.Set<T>().Find(id);
    }

    public virtual async Task<T> GetByIdAsync(T_KEY id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public virtual IQueryable<T> Query()
    {
        return _context.Set<T>().AsNoTracking();
    }

}