using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using sbojWebApp.Data;
using sbojWebApp.Models;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Globalization;

namespace sbojWebApp.Controllers
{
    public class CityController : Controller
    {
		private readonly ApplicationDbContext _context;
        public const int PageSize = 10;

        public CityController(ApplicationDbContext context)
		{
			_context = context;
		}

        private void SaveToJsonFile(City city)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cities.json");
            var cities = new List<City>();

            if (System.IO.File.Exists(filePath))
            {
                var jsonData = System.IO.File.ReadAllText(filePath);
                cities = JsonConvert.DeserializeObject<List<City>>(jsonData) ?? new List<City>();
            }

            cities.Add(city);

            var updatedJson = JsonConvert.SerializeObject(cities, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(filePath, updatedJson);
        }

        private void RemoveFromJsonFile(int id)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cities.json");

            if (!System.IO.File.Exists(filePath))
                return;

            var jsonData = System.IO.File.ReadAllText(filePath);
            var cities = JsonConvert.DeserializeObject<List<City>>(jsonData) ?? new List<City>();

            var userToRemove = cities.SingleOrDefault(u => u.Id == id);
            if (userToRemove != null)
            {
                cities.Remove(userToRemove);

                var updatedJson = JsonConvert.SerializeObject(cities, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(filePath, updatedJson);
            }
        }

		public IActionResult ExportDataToJson()
		{
			var cities = _context.Cities.ToList();

			var jsonData = JsonConvert.SerializeObject(cities, Newtonsoft.Json.Formatting.Indented);

			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "cities.json");
			System.IO.File.WriteAllText(filePath, jsonData);

			return Content($"Data exported to {filePath}");
		}

		// GET: City

		public IActionResult Index(int page = 1, string sortBy = "id")
        {
            var cities = _context.Cities.AsQueryable();

            switch(sortBy.ToLower())
            {
                case "name":
                    cities = cities.OrderBy(c => c.Name);
                    break;

                case "latitude":
                    cities = cities.OrderBy(c => c.Latitude);
                    break;

                case "longitude":
                    cities = cities.OrderBy(c => c.Longitude);
                    break;

                default:
                    cities = cities.OrderBy(c => c.Id);
                    break;
            }

            if (page < 1)
                page = 1;

            int itemCount = cities.Count();

            int itemsSkipped = (page - 1) * PageSize;

            int startItemsShowing = itemsSkipped + 1;
            int endItemsShowing = startItemsShowing + PageSize - 1;

            var pager = new Pager(startItemsShowing, endItemsShowing, itemCount, page, PageSize);

            this.ViewBag.Pager = pager;

            var sorter = new Sorter(sortBy);

            this.ViewBag.Sorter = sorter;

			var pageItems = cities.Skip(itemsSkipped).Take(PageSize).ToList();

			//return View(cities);

			return View(pageItems);
        }
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
                //SaveToJsonFile(city);
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

           // RemoveFromJsonFile(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
