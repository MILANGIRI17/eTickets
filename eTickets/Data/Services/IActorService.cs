using eTickets.Models;

namespace eTickets.Data.Services;

public interface IActorService
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<Actor?> GetByIdAsync(int id);
    Task AddAsync(Actor actor);
    Task<Actor> Update(int id, Actor newActor);
    void Delete(int id);

}
 