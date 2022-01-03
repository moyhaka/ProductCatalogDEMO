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
    [ApiController]
    [Route("api/")]

    public class ProductControllerAPI : ControllerBase
    {
       
        ProductsDAO products;

        [HttpGet]
        public ActionResult <IEnumerable<ProductModel>> Index()
        {
            products = new ProductsDAO();
            
            return products.GetAllProducts();
        }


        //put request
        //expect a json formatted object in the body of the request. 
        //id number must match the item being modified 
        [HttpPut("ProcessEdit")]
        public ActionResult <ProductModel> ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return products.GetProductById(product.Id);
        }

        /*

        public IActionResult Edit(int id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel foundProduct = products.GetProductById(id);
            return View("ShowEdit", foundProduct);
        }
*/
        [HttpDelete("Delete/{Id}")]
        public ActionResult <int> Delete(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(Id);

            //behöver skriva en ny Delete metod - är nog enklast så.
            int success = products.Delete(product);
            Console.WriteLine(success);
            return success;
            
        }

        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult<IEnumerable<ProductModel>> SearchResult(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();

            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return productList;
        }



        [HttpGet("ShowOneProduct/{Id}")]
        public ActionResult <ProductModel> ShowOneProduct(int Id)
        {

            ProductsDAO products = new ProductsDAO();

            return products.GetProductById(Id);
        }


        //Equivalent to InsertOne
        //post action
        // expecting a product in json format in the body of the request.
        [HttpPost("ProcessCreate")]
        public ActionResult <int> ProcessCreate(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            //insert instead
            int newId = products.Insert(product);
            return newId;
        }
    }
}
