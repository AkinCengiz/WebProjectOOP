using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjectOOP.Context;
using WebProjectOOP.Entities;

namespace WebProjectOOP.Controllers
{
    public class CustomerController : Controller
    {
        private DbEntityContext context = new DbEntityContext();
        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (customer.CustomerName.Length >= 6 && customer.CustomerCity.Length >= 3)
            {
                var addedCustomer = context.Entry(customer);
                addedCustomer.State = EntityState.Added;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }
        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var value = context.Customers.SingleOrDefault(c => c.CustomerID == id);
            return View(value);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(Customer customer)
        {
            var deletedCustomer = context.Entry(customer);
            deletedCustomer.State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = context.Customers.SingleOrDefault(c => c.CustomerID == id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var updatedCustomer = context.Entry(customer);
            updatedCustomer.State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
