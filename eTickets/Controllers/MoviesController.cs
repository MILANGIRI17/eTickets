﻿using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace eTickets.Controllers;

public class MoviesController : Controller
{
    private readonly AppDbContext context;

    public MoviesController(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IActionResult> Index()
    {
        var data = await context.Movies.Include(x=>x.Cinema).OrderBy(x=>x.Name).ToListAsync();
        return View(data);
    }
}
