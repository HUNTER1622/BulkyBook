using BulkyBook.DataAccess;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext db;
        public CategoryController(ApplicationDBContext _db)
        {
           db = _db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> Categorylist = db.Categories;
            return View(Categorylist);
        }
        //Get Create Section
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            //Custom validation we can add through key value pairs
            //Server-Side Validation
            if(model.Name == model.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Both values are not same");
            }
            if(ModelState.IsValid)
            {
                db.Categories.Add(model);
                db.SaveChanges();
                TempData["Success"] = "Created Sucessfully";
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }
        //Edit Section
        public IActionResult Edit(int? id)
        {
            if(id == null || id < 0)
            {
                return NotFound();
            }
            var CategoryDetail = db.Categories.Find(id);
            if(CategoryDetail == null)
            {
                return NotFound();
            }
            return View(CategoryDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (model == null)
            {
                return NotFound();
            }
            db.Categories.Update(model);
            db.SaveChanges();
            TempData["Success"] = "Updated Sucessfully";
            return RedirectToAction(nameof(Index));
        }
        //Delete Category
        public IActionResult Delete(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }
            var CategoryDetail = db.Categories.Find(id);
            return View(CategoryDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category model)
        {
            if (model == null)
            {
                return NotFound();
            }
            db.Categories.Remove(model);
            db.SaveChanges();
            TempData["Success"] = "Deleted Sucessfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
