using eTickets.Models;

namespace eTickets.Data.Services;

public interface IActorService
{
    Task<IEnumerable<Actor>> GetAll();
    Task<Actor> GetById(string id);
    void Add(Actor actor);
    Task<Actor> Update(int id, Actor newActor);
    void Delete(int id);

}
