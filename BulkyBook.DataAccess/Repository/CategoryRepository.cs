using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Model;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _db;
        public CategoryRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category model)
        {
            _db.Categories.Update(model);
        }
    }
}
