using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfExample
{
    public class DataService
    {
        static void Main(string[] args)
        {
            
        }

        //Category
        public List<Category> GetCategories()
        {
            var db = new NorthwindContext();
            return db.Categories.ToList<Category>();
        }

        public Category GetCategory(int id)
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.Find(id);
                if (category == null) return null;
                return category;
            }
        }

        public Category CreateCategory(string name, string description)
        {
            using (var db = new NorthwindContext())
            {
                var category = new Category { Name = name, Description = description };
                db.Categories.Add(category);
                db.SaveChanges();
                return category;
            }
        }

        public bool UpdateCategory(int Id, string Name, String Description)
        {
            using (var db = new NorthwindContext())
            {
                Category category = db.Categories.Find(Id);
                if (category == null) return false;
                else
                {
                    category.Name = Name;
                    category.Description = Description;
                    db.SaveChanges();
                    return true; 
                }
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.Find(id);
                if (category == null) return false;
                else
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public static void Delete(int id)
        {
            using (var db = new NorthwindContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                if (category.Id == id)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    Console.WriteLine("Category deleted ");

                }
            }
            
        }

        //Product
        public Product GetProduct(int id)
        {
            using (var db = new NorthwindContext())
            {
                var product = db.Products.Find(id);

                if (product == null) return null;
                return db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            }
        }

        public List<Product> GetProductByName(string s)
        {
            var db = new NorthwindContext();
            return db.Products.Include(x => x.Category).Where(x => x.Name.ToLower().Contains(s.ToLower())).ToList<Product>();
        }

        public List<Product> GetProductByCategory(int id)
        {
            var db = new NorthwindContext();
            return db.Products.Include(x => x.Category).Where(x => x.Category.Id == id).ToList<Product>();
        }

        //Order
        public Order GetOrder(int id)
        {
            using (var db = new NorthwindContext())
            {
                var order = db.Orders.Include(x => x.OrderDetails).FirstOrDefault(x => x.Id == id);

                foreach (var orderd in order.OrderDetails)
                {
                    orderd.Order = order;
                    orderd.Product = db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == orderd.ProductId);
                }
                return order;
            }
            
        }

        public List<dynamic> GetOrders()
        {
            var db = new NorthwindContext();
            return db.Orders.Select(x => new { x.Id, x.Date, x.Required, x.ShipName, x.ShipCity }).ToList<dynamic>();
        }

        //OrderDetails


        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            var db = new NorthwindContext();
            return db.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product).Include(x => x.Order).ToList<OrderDetails>();
        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            var db = new NorthwindContext();
            return db.OrderDetails.Where(x => x.ProductId == id).Include(x => x.Product).Include(x => x.Order).ToList<OrderDetails>();
        }
    }
}

