using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_API_Forecast.Data;
using Web_API_Forecast.Models;

namespace Web_API_Forecast.Controllers
{
    public class WeatherDataController : Controller
    {
        private readonly AppDatabaseContext _context;

        public WeatherDataController(AppDatabaseContext context)
        {
            _context = context;
        }

        // GET: WeatherData
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherData.ToListAsync());
        }

        // GET: WeatherData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherData = await _context.WeatherData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherData == null)
            {
                return NotFound();
            }

            return View(weatherData);
        }

        // GET: WeatherData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] WeatherData weatherData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherData);
        }

        // GET: WeatherData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherData = await _context.WeatherData.FindAsync(id);
            if (weatherData == null)
            {
                return NotFound();
            }
            return View(weatherData);
        }

        // POST: WeatherData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] WeatherData weatherData)
        {
            if (id != weatherData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherDataExists(weatherData.Id))
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
            return View(weatherData);
        }

        // GET: WeatherData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherData = await _context.WeatherData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherData == null)
            {
                return NotFound();
            }

            return View(weatherData);
        }

        // POST: WeatherData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherData = await _context.WeatherData.FindAsync(id);
            if (weatherData != null)
            {
                _context.WeatherData.Remove(weatherData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherDataExists(int id)
        {
            return _context.WeatherData.Any(e => e.Id == id);
        }
    }
}
