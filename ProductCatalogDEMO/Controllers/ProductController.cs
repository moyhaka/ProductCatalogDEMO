using ProductCatalogDEMO.Models;
using ProductCatalogDEMO.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogDEMO.Controllers
{
    public class ProductController : Controller
    {
        ProductsDAO products;
        public IActionResult Index()
        {
            products = new ProductsDAO();
            
            return View(products.GetAllProducts());
        }

        public IActionResult ShowDetails(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }

        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return PartialView("_productCard", product);
        }

        public IActionResult Delete(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(Id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }


        public IActionResult SearchResult(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();

            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return View( "index", productList);
        }

        public IActionResult Message() {
            return View("message");
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult ShowOneProduct(int Id)
        {
            return View(products.GetProductById(Id));
        }

        public IActionResult ShowOneProductJSON(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(Id);
            return Json(foundProduct);
        }

        public IActionResult Create(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowCreate", foundProduct);
        }


        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            //insert instead
            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }


        public IActionResult Welcome(string name, int secretNumber=3)
        {
            //Lägger ett värde i en viewbag som sedan kan hämtas för att ex display.
            ViewBag.Name = name;
            ViewBag.Secret = secretNumber; 
            return View();
        }
    }
}
