﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using sbojWebApp.Data;
using sbojWebApp.Models;

namespace sbojWebApp.Controllers
{
    public class CityController : Controller
    {
		private readonly ApplicationDbContext _context;
        private const int PageSize = 15;

		public CityController(ApplicationDbContext context)
		{
			_context = context;
		}

        // GET: City

        //public IActionResult Index()
        //{
        //    var cities = _context.Cities.ToList();
        //    return View(cities);
        //}

        // GET: City (Page)
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            var cities = _context.Cities.OrderBy(c => c.Name).ToPagedList(pageNumber, PageSize);
            return View(cities);
        }

        // GET: City/Details/id
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var city = _context.Cities.FirstOrDefault(c => c.Id == id);
            if (city == null)
                return NotFound();

            return View(city);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Latitude,Longitude")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: City/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var city = _context.Cities.Find(id);
            if (city == null)
                return NotFound();

            return View(city);
        }

        // POST: City/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Latitude,Longitude")] City city)
        {
            if (id != city.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: City/Delete/id
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var city = _context.Cities
                .FirstOrDefault(m => m.Id == id);
            if (city == null)
                return NotFound();

            return View(city);
        }

        // POST: City/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var city = _context.Cities.Find(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
