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

        public void Delete(int id)
        {
            throw new NotImplementedException();
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

        public Task<Actor> Update(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }
    }
}
