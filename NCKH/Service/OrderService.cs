using NCKH.Datta;
using NCKH.Models;
using static NuGet.Packaging.PackagingConstants;

namespace NCKH.Service
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAllCategory()
        {
            return _context.Orders.ToList();
        }
        public int AddCOrder(Order Order)
        {
            _context.Orders.Add(Order);
            _context.SaveChanges();
            return Order.Id;
        }
        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateCategory(Order Order)
        {
            var existingemployee = _context.Orders.SingleOrDefault(u => u.Id == Order.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(Order);
            }
            else
            {
                _context.Orders.Update(Order);
            }
            _context.SaveChanges();
        }
       
    }

}
