using Microsoft.EntityFrameworkCore;
using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProduct()
        {
            return _context.Products.Include(e => e.Category).ToList();
        }
        public void AddProduct(Product Product)
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
        }
        public Product GetProductById(int id)
        {
            return _context.Products
                           .Include(e => e.Category)
                           .FirstOrDefault(p => p.Id == id);
        }
     
        public void UpdateEProduct(Product Product)
        {
            var existingemployee = _context.Products.SingleOrDefault(u => u.Id == Product.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(Product);
            }
            else
            {
                _context.Products.Update(Product);
            }
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var Products= _context.Products.Find(id);
            if (Products != null)
            {
                _context.Products.Remove(Products);
                _context.SaveChanges();
            }

        }
    }

}
