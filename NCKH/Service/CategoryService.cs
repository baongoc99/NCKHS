using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }
        public void AddCCategory(Category Category)
        {
            _context.Categories.Add(Category);
            _context.SaveChanges();
        }
        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }
       
        public void UpdateCategory(Category Category)
        {
            var existingemployee = _context.Categories.SingleOrDefault(u => u.Id == Category.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(Category);
            }
            else
            {
                _context.Categories.Update(Category);
            }
            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var Categorys = _context.Categories.Find(id);
            if (Categorys != null)
            {
                _context.Categories.Remove(Categorys);
                _context.SaveChanges();
            }

        }
    }

}
