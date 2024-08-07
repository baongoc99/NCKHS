using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using NCKH.Service;

namespace NCKH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;
        public CategoryController(CategoryService categoryService) {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            List<Category> categories = categoryService.GetAllCategory();
            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        public IActionResult Create(Category category)
        {
            categoryService.AddCCategory(category);
            return Redirect("/admin/category");
        }
        public IActionResult EditCategory(int id)
        {
            Category category = categoryService.GetCategoryById(id);
            return View(category);
        }
        public IActionResult Edit(Category category)
        {
            categoryService.UpdateCategory(category);
            return Redirect("/admin/category");
        }
        public IActionResult Delete(int id)
        {
            categoryService.DeleteCategory(id);
            return Redirect("/admin/category");
        }
    }
}
