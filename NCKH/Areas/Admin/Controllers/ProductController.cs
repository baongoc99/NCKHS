using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using NCKH.Service;

namespace NCKH.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;
        public ProductController(ProductService productService, CategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            List<Product> products = productService.GetAllProduct();
            return View(products);
        }
        public IActionResult CreateProduct()
        {
            List<Category> categories = categoryService.GetAllCategory();
            return View(categories);
        }
        public IActionResult Create(Product product, IFormFile image)
        {
            if (image != null)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return Redirect($"/Admin/UserRoles/IndexUserRoles");
                }
                // Ensure unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
                // Create directory if it doesn't exist
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                try
                {
                    // Save the file
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
                catch (Exception ex)
                {
                    // Handle file saving exceptions
                    // Optionally log the error and return an appropriate view
                    return RedirectToAction("Error", "Home");
                }
                var relativePath = Path.Combine("images", uniqueFileName).Replace("\\", "/");
                product.Image = relativePath;
            }
            else
            {
                product.Image = "images/default.jpg";
            }
            productService.AddProduct(product);
            return Redirect($"/Admin/Product");
        }

        public IActionResult EditProduct(int id)
        {
            List<Category> categories = categoryService.GetAllCategory();
            Product product = productService.GetProductById(id);
            ModelDataset modelDataset = new ModelDataset()
            { 
                product = product,
                categories = categories 
            };
            return View(modelDataset);
        }
        public IActionResult Edit(Product product, IFormFile image)
        {
            if (image != null)
            {
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return Redirect($"/Admin/UserRoles/IndexUserRoles");
                }
                // Ensure unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);
                // Create directory if it doesn't exist
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                try
                {
                    // Save the file
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
                catch (Exception ex)
                {
                    // Handle file saving exceptions
                    // Optionally log the error and return an appropriate view
                    return RedirectToAction("Error", "Home");
                }
                var relativePath = Path.Combine("images", uniqueFileName).Replace("\\", "/");
                product.Image = relativePath;
            }
            else
            {
                product.Image = "images/default.jpg";
            }
            // Sử dụng phương thức UpdateProduct đã sửa đổi
            productService.UpdateEProduct(product);
            return Redirect($"/Admin/Product");

        }
        public IActionResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return Redirect("/admin/product");
        }
    }
}
