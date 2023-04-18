using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Data.Base;

public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext context;

    public EntityBaseRepository(AppDbContext context)
    {
        this.context = context;
    }
    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        var entity=await context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
        EntityEntry entityEntry =  context.Entry<T>(entity);
        entityEntry.State = EntityState.Deleted;
    }

    public async Task<IEnumerable<T>> GetAllAsync()=> await context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id)=> await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

    public async Task UpdateAsync(int id, T entity)
    {
        EntityEntry entityEntry = context.Entry<T>(entity);
        entityEntry.State = EntityState.Modified;
    }
}
 