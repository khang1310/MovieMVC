using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class MoviesController : Controller
    {
        private readonly MovieReadRepository readRepository;
        private readonly MovieWriteRepository writeRepository;

        public MoviesController(MovieReadRepository readRepository, MovieWriteRepository writeRepository)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
        }

        // GET: Movies
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Index()
        {
              return View(await readRepository.GetAll());
        }

        // GET: Movies
        [MapToApiVersion("2.0")]
        public string Get()
        {
            return "Version 2.0";
        }

        // GET: Movies/Details/5
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Details(int id)
        {
            Movie movie = await readRepository.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        [MapToApiVersion("1.0")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [MapToApiVersion("1.0")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await writeRepository.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Edit(int id)
        {
            Movie movie = await readRepository.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Edit/5
        [MapToApiVersion("1.0")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await writeRepository.Update(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(int id)
        {
            Movie movie = await readRepository.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [MapToApiVersion("1.0")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await writeRepository.Delete(id);
            if (movie == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return writeRepository.MovieExists(id);
        }
    }
}
