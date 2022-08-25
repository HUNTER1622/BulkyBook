using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _db;
        public CoverTypeController(IUnitOfWork db)
        {
            _db = db;  
        }
        public IActionResult Index()
        {
            var data = _db.CoverType.GetAll();
            return View(data);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult Add(CoverType model)
        {
            if (ModelState.IsValid)
            {
                _db.CoverType.Add(model);
                _db.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetDetailsById(int id)
        {
            var databyid = _db.CoverType.GetFirstOrDefault(x=>x.CoverTypeId == id); 
            return View(databyid);
        }

        [HttpPost]
        public IActionResult Edit(CoverType model)
        {
            if(ModelState.IsValid)
            {
                _db.CoverType.Update(model);
                _db.Save();
            }
           
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var datadeletebyid = _db.CoverType.GetFirstOrDefault(x=>x.CoverTypeId==id);
            if(datadeletebyid!=null)
            {
                _db.CoverType.Remove(datadeletebyid);
                _db.Save();
            }
               
            return RedirectToAction(nameof(Index));
        }
    }
}
