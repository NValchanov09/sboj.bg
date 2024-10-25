using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using sbojWebApp.Data;
using sbojWebApp.Models;

namespace sbojWebApp.Controllers
{
    public class CompanyController : Controller
    {
		private readonly ApplicationDbContext _context;

		public CompanyController(ApplicationDbContext context)
		{
			_context = context;
		}

		private void SaveToJsonFile(Company company)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "companies.json");
			var companies = new List<Company>();

			if (System.IO.File.Exists(filePath))
			{
				var jsonData = System.IO.File.ReadAllText(filePath);
				companies = JsonConvert.DeserializeObject<List<Company>>(jsonData) ?? new List<Company>();
			}

			companies.Add(company);

			var updatedJson = JsonConvert.SerializeObject(companies, Newtonsoft.Json.Formatting.Indented);
			System.IO.File.WriteAllText(filePath, updatedJson);
		}

		private void RemoveFromJsonFile(int id)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "companies.json");

			if (!System.IO.File.Exists(filePath))
				return;

			var jsonData = System.IO.File.ReadAllText(filePath);
			var companies = JsonConvert.DeserializeObject<List<Company>>(jsonData) ?? new List<Company>();

			var userToRemove = companies.SingleOrDefault(u => u.Id == id);
			if (userToRemove != null)
			{
				companies.Remove(userToRemove);

				var updatedJson = JsonConvert.SerializeObject(companies, Newtonsoft.Json.Formatting.Indented);
				System.IO.File.WriteAllText(filePath, updatedJson);
			}
		}

		public IActionResult ExportDataToJson()
		{
			var companies = _context.Companies.ToList();

			var jsonData = JsonConvert.SerializeObject(companies, Newtonsoft.Json.Formatting.Indented);

			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "companies.json");
			System.IO.File.WriteAllText(filePath, jsonData);

			return Content($"Data exported to {filePath}");
		}

		public IActionResult DeleteAll()
		{
			var companies = _context.Companies.ToList();

			if (companies != null && companies.Count > 0)
			{
				_context.Companies.RemoveRange(companies);
				_context.SaveChanges();
			}

			return Content($"Deleted everything from the table");
		}

		// GET: Company
		public IActionResult Index(int page = 1, int pageSize = 10, string sortBy = "id")
		{
			var companies = _context.Companies.AsQueryable();

			int itemCount = companies.Count();

			Console.Write("THE CURRENT ITEM COUNT IS : ");
			Console.WriteLine(itemCount);

			var pageSizeOptions = new List<SelectListItem>
			{
				new SelectListItem { Value = "5", Text = "5", Selected = pageSize == 5 },
				new SelectListItem { Value = "10", Text = "10", Selected = pageSize == 10 },
				new SelectListItem { Value = "15", Text = "15", Selected = pageSize == 15 },
				new SelectListItem { Value = "25", Text = "25", Selected = pageSize == 25 },
				new SelectListItem { Value = "50", Text = "50", Selected = pageSize == 50 },
				new SelectListItem { Value = $"{itemCount}", Text = "All", Selected = pageSize == itemCount }
			};

			ViewBag.PageSizes = pageSizeOptions;

			switch (sortBy.ToLower())
			{
				case "name":
					companies = companies.OrderBy(c => c.Name);
					break;

				case "website":
					companies = companies.OrderBy(c => c.Website);
					break;

				case "phonenumber":
					companies = companies.OrderBy(c => c.PhoneNumber);
					break;

				default:
					companies = companies.OrderBy(c => c.Id);
					break;
			}

			if (page <= 0 || page > itemCount)
				page = 1;

			if (pageSize <= 0)
				pageSize = 10;

			if (pageSize > itemCount && itemCount > 0)
				pageSize = itemCount;

			if ((page - 1) * pageSize > itemCount)
				page = 1;

			int itemsSkipped = (page - 1) * pageSize;

			int startItemsShowing = itemsSkipped + 1;
			int endItemsShowing = startItemsShowing + pageSize - 1;

			var pager = new Pager(startItemsShowing, endItemsShowing, itemCount, page, pageSize);

			this.ViewBag.Pager = pager;

			var sorter = new Sorter(sortBy);

			this.ViewBag.Sorter = sorter;

			var pageItems = companies.Skip(itemsSkipped).Take(pageSize).ToList();

			return View(pageItems);
		}

		// GET: Company/Details/id
		public IActionResult Details(int? id)
		{
			if (id == null)
				return NotFound();

			var company = _context.Companies.FirstOrDefault(c => c.Id == id);
			if (company == null)
				return NotFound();

			return View(company);
		}

		// GET: Company/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Company/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("Id,Name,Description,ImageURL,Website,LinkedIn,Facebook,Instagram,PhoneNumber")] Company company)
		{
			if (ModelState.IsValid)
			{
				_context.Add(company);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(company);
		}

		// GET: Company/Edit/id
		public IActionResult Edit(int? id)
		{
			if (id == null)
				return NotFound();

			var company = _context.Companies.Find(id);
			if (company == null)
				return NotFound();

			return View(company);
		}

		// POST: Company/Edit/id
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("Id,Name,Description,ImageURL,Website,LinkedIn,Facebook,Instagram,PhoneNumber")] Company company)
		{
			if (id != company.Id)
				return NotFound();

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(company);
					_context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CompanyExists(company.Id))
						return NotFound();
					else
						throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(company);
		}

		// GET: Company/Delete/id
		public IActionResult Delete(int? id)
		{
			if (id == null)
				return NotFound();

			var company = _context.Companies
				.FirstOrDefault(m => m.Id == id);
			if (company == null)
				return NotFound();

			return View(company);
		}

		// POST: Company/Delete/id
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var company = _context.Companies.Find(id);
			_context.Companies.Remove(company);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteSelectedCompanies([FromBody] int[] companyIds)
		{
			if (companyIds == null)
			{
				return Json(new { success = false, message = "companyIds is null." });
			}
			if (companyIds.Length == 0)
			{
				return Json(new { success = false, message = "No companies selected for deletion." });
			}

			try
			{
				var companiesToDelete = _context.Companies.Where(c => companyIds.Contains(c.Id)).ToList();
				_context.Companies.RemoveRange(companiesToDelete);
				_context.SaveChanges();

				return Json(new { success = true });
			}
			catch (Exception ex)
			{
				return Json(new { success = false, message = "Error deleting companies: " + ex.Message });
			}
		}
		private bool CompanyExists(int id)
		{
			return _context.Companies.Any(e => e.Id == id);
		}
	}
}
