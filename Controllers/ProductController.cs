using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjectOOP.Context;
using WebProjectOOP.Entities;

namespace WebProjectOOP.Controllers
{
    public class ProductController : Controller
    {
        private DbEntityContext entityContext = new DbEntityContext();
        public IActionResult Index()
        {
            var values = entityContext.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var addProducts = entityContext.Entry(product);
            addProducts.State = EntityState.Added;
            entityContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var deleteProduct = entityContext.Products.SingleOrDefault(p => p.ProductId == id);
            entityContext.Remove(deleteProduct);
            //var deleteProduct = entityContext.Entry(product);
            //deleteProduct.State = EntityState.Deleted;
            entityContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = entityContext.Products.SingleOrDefault(p => p.ProductId == id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var updatedProduct = entityContext.Entry(product);
            updatedProduct.State = EntityState.Modified;
            entityContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
