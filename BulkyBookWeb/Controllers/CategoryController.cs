using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork db;
        public CategoryController(IUnitOfWork _db)
        {
           db = _db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> Categorylist = db.Category.GetAll();
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
                db.Category.Add(model);
                db.Save();
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
            var CategoryDetail = db.Category.GetFirstOrDefault(x=> x.Id == id);
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
            db.Category.Update(model);
            db.Save();
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
            var CategoryDetail = db.Category.GetFirstOrDefault(x=>x.Id==id);
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
            db.Category.Remove(model);
            db.Save();
            TempData["Success"] = "Deleted Sucessfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
