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
        public IActionResult Index()
        {
            ProductsDAO products = new();
            
            return View(products.GetAllProducts());
        }

        public IActionResult ShowDetails(int id)
        {
            ProductsDAO products = new();
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }

        public IActionResult Edit(int id)
        {
            ProductsDAO products = new();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit", foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Delete(int Id)
        {
            ProductsDAO products = new();
            ProductModel product = products.GetProductById(Id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }


        public IActionResult SearchResult(string searchTerm)
        {
            ProductsDAO products = new();

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


        public IActionResult Create(int id)
        {
            ProductsDAO products = new ();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowCreate", foundProduct);
        }


        public IActionResult ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new();
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
