using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class PaymentService
    {
        private readonly ApplicationDbContext _context;
        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }
        public void AddCPayment(Payment Paymen)
        {
            _context.Payments.Add(Paymen);
            _context.SaveChanges();
        }

       
      
    }

}
