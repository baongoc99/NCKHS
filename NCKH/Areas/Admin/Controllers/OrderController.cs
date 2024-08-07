using Microsoft.AspNetCore.Mvc;
using NCKH.Models;
using NCKH.Service;
using System.Collections.Generic;

namespace NCKH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly OrderDetailService orderDetailService;
        private readonly ProductService productService;
        private readonly CustomerService customerService;
        private readonly OrderDetailCustomerService orderDetailCustomerService;
        private readonly PaymentService paymentService;
        public OrderController(OrderService orderService,
            OrderDetailService orderDetailService,
            ProductService productService,
            CustomerService customerService,
            OrderDetailCustomerService orderDetailCustomerService,
            PaymentService paymentService)
        {
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.productService = productService;
            this.customerService = customerService;
            this.orderDetailCustomerService = orderDetailCustomerService;
            this.paymentService = paymentService;
        }

        public IActionResult Index()
        {
            List<Product> products = productService.GetAllProduct();
            List<OrderDetailCustomer> orderDetailCustomers = orderDetailCustomerService.GetAllOrderDetailCustomer();
            ModelDataset modelDataset = new ModelDataset()
            {
                listproduct = products,
                orderDetailCustomers = orderDetailCustomers,
            };
            return View(modelDataset);
        }
        public ActionResult Addorderdetals(int idproduct)
        {

            OrderDetailCustomer check = orderDetailCustomerService.GetOrderDetailCustomerByIdproduct(idproduct);
            Product product = productService.GetProductById(idproduct);
            if (check == null)
            {
                OrderDetailCustomer orderDetailCustomer = new OrderDetailCustomer();
                orderDetailCustomer.ProductId = idproduct;
                orderDetailCustomer.Quantity = 1;
                orderDetailCustomer.TotalPrice = product.Price * orderDetailCustomer.Quantity;
                orderDetailCustomerService.AddOrderDetailCustomer(orderDetailCustomer);
                /// update số lượng
                product.Quantity -= 1;
                productService.UpdateEProduct(product);
                return Redirect("/admin/order");

            }
            else
            {
                check.Quantity += 1;
                check.TotalPrice = product.Price * check.Quantity;
                orderDetailCustomerService.UpdateOrderDetailCustomer(check);
                product.Quantity -= 1;
                productService.UpdateEProduct(product);
                return Redirect("/admin/order");

            }
        }
        public IActionResult DeleteorderDetailCustomer(int id, int idproduct)
        {
            OrderDetailCustomer orderDetailCustomer = orderDetailCustomerService.GetOrderDetailCustomerById(id);
            Product product = productService.GetProductById(idproduct);
            product.Quantity = orderDetailCustomer.Quantity + product.Quantity;
            productService.UpdateEProduct(product);
            orderDetailCustomerService.DeleteOrderDetailCustomers(id);
            return Redirect("/admin/order");
        }

        public IActionResult ThanhToan(Customer customer)
        {
            customer.Address = "null";
            customer.Password = "null";
            customer.RecordCreatedOn = DateTime.Now;
            int idcustomer = customerService.AddCustomer(customer);
            List<OrderDetailCustomer> orderDetailCustomer = orderDetailCustomerService.GetAllOrderDetailCustomer();
            decimal total = orderDetailCustomer.Sum(o => o.TotalPrice);
            Order order = new Order();
            order.CustomerId = idcustomer;
            order.Status = "đã giao";
            order.Total = total;
            int idorder = orderService.AddCOrder(order);
            OrderDetail orderDetail = new OrderDetail();    
            foreach(var orderdetal in orderDetailCustomer)
            {
                orderDetail.Quantity = orderdetal.Quantity;
                orderDetail.TotalPrice = orderdetal.TotalPrice;
                orderDetail.StartDattetime = DateTime.Now;
                orderDetail.OrderId = idorder;
                orderDetail.ProductId = orderdetal.ProductId;
                orderDetailService.AddCOrder(orderDetail);
                orderDetailCustomerService.DeleteOrderDetailCustomers(orderdetal.Id);
            }
            Payment payment = new Payment();
            payment.EndDattetime = DateTime.Now;
            payment.Total = total;
            payment.OrderId = idorder;


            return Redirect("/admin/order");
        }

    }
}
