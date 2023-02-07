using Ecommercely.Web.Data;
using Ecommercely.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercely.Web.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Category> categoryList = _db.Categories;
			return View(categoryList);
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Add(category);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(category);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var category = _db.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(category);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(category);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var category = _db.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var category = _db.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}

			_db.Categories.Remove(category);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		
	}
}
