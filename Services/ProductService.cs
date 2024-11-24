using System.Collections.Generic;
using System.Linq;
using MVC_ProductDemo.Models;
namespace MVC_ProductDemo.Services;

    public class ProductService
    {
        public static List<Product> products;
        static ProductService()
        {
            products = new List<Product>()
            {
                new Product() {Id = 101, Name="Biscuit", Price=15},
                new Product() {Id = 102, Name="Butter Milk", Price=30},
                new Product() {Id = 103, Name="Potato Chips", Price=20},
                new Product() {Id = 104, Name="Chocolates", Price=10},
                new Product() {Id = 105, Name="Ice Cream", Price=50},
                new Product() {Id = 106, Name="Lassi", Price=35}
            };
        }
        public static List<Product>GetAllProducts()
        {
            return products;
        }
        public static Product GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }
        public static int nextId = 107;
        public static void AddProduct(Product product)
        {
            product.Id = nextId;
            products.Add(product);
            nextId++;
        }
        public static void UpdateProduct(Product modifiedproduct)
        {
            int index = products.FindIndex(x => x.Id == modifiedproduct.Id);
            if(index == -1)
            {
                return;
            }
            else
            {
                products[index] = modifiedproduct;
            }
        }
        public static void DeleteProduct(Product product)
        {
            var prod = GetProductById(product.Id);
            if(prod == null)
            {
                return;
            }
            else
            {
                products.Remove(product);
            }
        }
    }
