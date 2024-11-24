using Microsoft.AspNetCore.Mvc;
using MVC_ProductDemo.Services;
using MVC_ProductDemo.Models;
namespace MVC_ProductDemo.Controllers;

    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var productlist = ProductService.GetAllProducts();
            return View(productlist);
            return Index();
        }
        public IActionResult List()
        {
            var productlist = ProductService.GetAllProducts();
            return View(productlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product newproduct)
        {
            newproduct.Id = ProductService.nextId;
            ProductService.AddProduct(newproduct);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = ProductService.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            ProductService.UpdateProduct(product);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = ProductService.GetProductById(id);
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = ProductService.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            var data = ProductService.GetProductById(id);
            if(data == null)
            {
                return View();
            }
            else
            {
                ProductService.DeleteProduct(data);
                return RedirectToAction("Index");
            }
        }
    }
