using Microsoft.AspNetCore.Mvc;
using WebProjectOOP.Context;

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
    }
}
