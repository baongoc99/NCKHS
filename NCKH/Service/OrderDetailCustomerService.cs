using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class OrderDetailCustomerService
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailCustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderDetailCustomer> GetAllOrderDetailCustomer()
        {
            return _context.OrderDetailCustomers.ToList();
        }
        public void AddOrderDetailCustomer(OrderDetailCustomer OrderDetailCustomer)
        {
            _context.OrderDetailCustomers.Add(OrderDetailCustomer);
            _context.SaveChanges();
        }
        public OrderDetailCustomer GetOrderDetailCustomerById(int id)
        {
            return _context.OrderDetailCustomers.FirstOrDefault(p => p.Id == id);
        }
        public OrderDetailCustomer GetOrderDetailCustomerByIdproduct(int idproduct)
        {
            return _context.OrderDetailCustomers.FirstOrDefault(p => p.ProductId == idproduct);
        }

        public void UpdateOrderDetailCustomer(OrderDetailCustomer OrderDetail)
        {
            var existingemployee = _context.OrderDetailCustomers.SingleOrDefault(u => u.Id == OrderDetail.Id);
            if (existingemployee != null)
            {
                _context.Entry(existingemployee).CurrentValues.SetValues(OrderDetail);
            }
            else
            {
                _context.OrderDetailCustomers.Update(OrderDetail);
            }
            _context.SaveChanges();
        }
        public void DeleteOrderDetailCustomers(int id)
        {
            var OrderDetailCustomers = _context.OrderDetailCustomers.Find(id);
            if (OrderDetailCustomers != null)
            {
                _context.OrderDetailCustomers.Remove(OrderDetailCustomers);
                _context.SaveChanges();
            }

        }
    }

}
