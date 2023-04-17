using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext context;

        public ActorService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Actor actor)
        {
            context.Actors.Add(actor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            context.Actors.Remove(result);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor?> GetByIdAsync(int id)
        {
            var result = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            context.Update(actor);
            await context.SaveChangesAsync();
            return actor;
        }
    }
}
