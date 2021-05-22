using M2_NETCoreMVC.Web.Areas.Marketing.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Areas.Marketing.Controllers
{
    [Area("Marketing")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsWithViewModel()
        {
            var products = GetProductsJsonLocal();
            return View(products);
        }

        public IActionResult ProductsWithViewBag()
        {
            var products = GetProductsJsonLocal();
            ViewBag.ProductList = products;

            return View();
        }

        public IActionResult ProductsWithViewData()
        {
            var products = GetProductsJsonLocal();
            ViewData["ProductList"] = products;

            return View();
        }



        public List<Product> GetProductsJsonLocal()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"Areas\\Marketing\\Data\\Products.json");
            var json = System.IO.File.ReadAllText(folderDetails);

            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products;
        }



    }
}
