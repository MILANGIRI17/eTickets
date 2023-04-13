using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace eTickets.Controllers;

public class ActorsController : Controller
{
    private readonly IActorService service;

    public ActorsController(IActorService service)
    {
        this.service = service;
    }
    public async Task<IActionResult> Index()
    {
        var data = await service.GetAll();
        return View(data);
    }
}
