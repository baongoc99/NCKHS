using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }
        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id; // Giả định rằng thuộc tính ID của Customer là tự tăng
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == id);
        }
        public void UpdateCustomer(Customer Customer)
        {
            _context.Customers.Update(Customer);
            _context.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var Customers = _context.Customers.Find(id);
            if (Customers != null)
            {
                _context.Customers.Remove(Customers);
                _context.SaveChanges();
            }

        }
    }
}
