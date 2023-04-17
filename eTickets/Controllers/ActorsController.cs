using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
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
        var data = await service.GetAllAsync();
        return View(data);
    }

    //Get: Actors/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
    {
        if(!ModelState.IsValid)
        {
            return View(actor);
        }
        await service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    //Get: Actors/Details/1
    public async Task<IActionResult> Details(int id)
    {
        var actorDetail= await service.GetByIdAsync(id);
        if (actorDetail == null) return View("Empty");
        return View(actorDetail);
    }

    //Get: Actors/Edit/1
    public async Task<IActionResult> Edit(int id)
    {
        var actorDetail = await service.GetByIdAsync(id);
        if (actorDetail == null) return View("NotFound");
        return View(actorDetail);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }
        await service.UpdateAsync(id,actor);
        return RedirectToAction(nameof(Index));
    }

    //Get: Actors/Delete/1
    public async Task<IActionResult> Delete(int id)
    {
        var actor = await service.GetByIdAsync(id);
        if (actor == null) return View("NotFound");
        return View(actor);
    }

    [HttpPost,ActionName("Delete")]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actor=await service.GetByIdAsync(id);
        if(actor == null) return View("NotFound");
        await service.DeleteAsync(id); 
        return RedirectToAction(nameof(Index));
    }


}
