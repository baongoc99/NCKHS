namespace NCKH.Models
{
    public class ModelDataset
    {
        public List<Role> Roles { get; set; }
        public List<Category> categories { get; set; }
        public List<Product> listproduct { get; set; }

        public List<OrderDetailCustomer> orderDetailCustomers { get; set; }

        public Employee employee { get; set; }
        public Product product { get; set; }

    }
}
