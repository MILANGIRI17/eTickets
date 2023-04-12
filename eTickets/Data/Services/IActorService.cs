using eTickets.Models;

namespace eTickets.Data.Services;

public interface IActorService
{
    IEnumerable<Actor> GetAll();
}
