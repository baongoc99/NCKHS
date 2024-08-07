using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class SalesService
    {
        private readonly ApplicationDbContext _context;
        public SalesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sales> GetAllSales()
        {
            return _context.Sales.ToList();
        }
        public void AddCSales(Sales Sales)
        {
            _context.Sales.Add(Sales);
            _context.SaveChanges();
        }
        public Sales GetSalesById(int id)
        {
            return _context.Sales.FirstOrDefault(p => p.Id == id);
        }
        public void UpdateSales(Sales Sales)
        {
            _context.Sales.Update(Sales);
            _context.SaveChanges();
        }
        public void DeleteSales(int id)
        {
            var Saless = _context.Sales.Find(id);
            if (Saless != null)
            {
                _context.Sales.Remove(Saless);
                _context.SaveChanges();
            }

        }
    }

}
