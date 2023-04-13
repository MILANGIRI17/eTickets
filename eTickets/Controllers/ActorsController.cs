﻿using eTickets.Data;
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
        var data= await service.GetByIdAsync(id);
        if (data == null) return View("Empty");
        return View(data);
    }
}
