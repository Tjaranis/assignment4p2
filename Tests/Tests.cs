using EfExample;
using System;
using Xunit;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        /* Categories */

        [Fact] 
        //1 passed
        public void Category_Object_HasIdNameAndDescription()
        {
            var category = new Category();
            Assert.Equal(0, category.Id);
            Assert.Null(category.CategoryName);
            Assert.Null(category.Description);
        }
    


        [Fact]
        //2 passed
        public void GetAllCategories_NoArgument_ReturnsAllCategories()
        {
            var service = new DataService();
            var categories = service.GetCategories();
            Assert.Equal(8, categories.Count);
            Assert.Equal("Beverages", categories.First().CategoryName);
        }
        
        [Fact]
        //3 passed
        public void GetCategory_ValidId_ReturnsCategoryObject()
        {
            var service = new DataService();
            var category = service.GetCategory(1);
            Assert.Equal("Beverages", category.CategoryName);
        }
        
        [Fact]
        //4 passed
        public void CreateCategory_ValidData_CreteCategoryAndRetunsNewObject()
        {
            var service = new DataService();
            var category = service.CreateCategory("Test", "CreateCategory_ValidData_CreteCategoryAndRetunsNewObject");
            Assert.True(category.Id > 0);
            Assert.Equal("Test", category.CategoryName);
            Assert.Equal("CreateCategory_ValidData_CreteCategoryAndRetunsNewObject", category.Description);

            // cleanup
            service.DeleteCategory(category.Id);
        }
        
        [Fact]
        //5 passed
        public void DeleteCategory_ValidId_RemoveTheCategory()
        {
            var service = new DataService();
            var category = service.CreateCategory("Test", "DeleteCategory_ValidId_RemoveTheCategory");
            var result = service.DeleteCategory(category.Id);
            Assert.True(result);
            category = service.GetCategory(category.Id);
            Assert.Null(category);
        }
        
        [Fact]
        //6 passed
        public void DeleteCategory_InvalidId_ReturnsFalse()
        {
            var service = new DataService();
            var result = service.DeleteCategory(-1);
            Assert.False(result);
        }
        
        [Fact]
        //7 passed
        public void UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
        {
            var service = new DataService();
            var category = service.CreateCategory("TestingUpdate", "UpdateCategory_NewNameAndDescription_UpdateWithNewValues");

            var result = service.UpdateCategory(category.Id, "UpdatedName", "UpdatedDescription");
            Assert.True(result);

            category = service.GetCategory(category.Id);

            Assert.Equal("UpdatedName", category.CategoryName);
            Assert.Equal("UpdatedDescription", category.Description);

            // cleanup
            service.DeleteCategory(category.Id);
        }
        
        [Fact]
        //8 passed
        public void UpdateCategory_InvalidID_ReturnsFalse()
        {
            var service = new DataService();
            var result = service.UpdateCategory(-1, "UpdatedName", "UpdatedDescription");
            Assert.False(result);
        }


        /* products */

        [Fact]
        //9 passed
        public void Product_Object_HasIdNameUnitPriceQuantityPerUnitAndUnitsInStock()
        {
            var product = new Product();
            Assert.Equal(0, product.Id);
            Assert.Null(product.Name);
            Assert.Equal(0.0, product.UnitPrice);
            Assert.Null(product.QuantityPerUnit);
            Assert.Equal(0, product.UnitsInStock);
        }
        
        [Fact]
        //10 passed
        public void GetProduct_ValidId_ReturnsProductWithCategory()
        {
            var service = new DataService();
            var product = service.GetProduct(1);
            Assert.Equal("Chai", product.Name);
            Assert.Equal("Beverages", product.Category.CategoryName);
        }
        
        

        [Fact]
        //11 passed
        public void GetProduct_NameSubString_ReturnsProductsThatMachesTheSubString()
        {
            var service = new DataService();
            var products = service.GetProductByName("ant");
            Assert.Equal(3, products.Count);
            Assert.Equal("Chef Anton's Cajun Seasoning", products.First().Name);
            Assert.Equal("Guaran� Fant�stica", products.Last().Name);
        }
        
        [Fact]
        //12 passed
        public void GetProductsByCategory_ValidId_ReturnsProductWithCategory()
        {
            var service = new DataService();
            var products = service.GetProductByCategory(1);
            Assert.Equal(12, products.Count);
            Assert.Equal("Chai", products.First().Name);
            Assert.Equal("Beverages", products.First().Category.CategoryName);
            Assert.Equal("Lakkalik��ri", products.Last().Name);
        }
        
        /* orders */
        [Fact]

        //13 passed
        public void Order_Object_HasIdDatesAndOrderDetails()
        {
            var order = new Order();
            Assert.Equal(0, order.Id);
            Assert.Equal(new DateTime(), order.Date);
            Assert.Equal(new DateTime(), order.Required);
            Assert.Null(order.OrderDetails);
            Assert.Null(order.ShipName);
            Assert.Null(order.ShipCity);
        }
        
        [Fact]
        //14
        public void GetOrder_ValidId_ReturnsCompleteOrder()
        {
            var service = new DataService();
            var order = service.GetOrder(10248);
            Assert.Equal(3, order.OrderDetails.Count);
            Assert.Equal("Queso Cabrales", order.OrderDetails.First().Product.Name);
            Assert.Equal("Dairy Products", order.OrderDetails.First().Product.Category.CategoryName);
        }
        
        [Fact]
        //15 passed
        public void GetOrders()
        {
            var service = new DataService();
            var orders = service.GetOrders();
            Assert.Equal(830, orders.Count);
        }

         
        /* orderdetails */



        [Fact]
       //16 passed
       public void OrderDetails_Object_HasOrderProductUnitPriceQuantityAndDiscount()
       {
           var orderDetails = new OrderDetails();
           Assert.Equal(0, orderDetails.OrderId);
           Assert.Null(orderDetails.Order);
           Assert.Equal(0, orderDetails.ProductId);
           Assert.Null(orderDetails.Product);
           Assert.Equal(0.0, orderDetails.UnitPrice);
           Assert.Equal(0.0, orderDetails.Quantity);
           Assert.Equal(0.0, orderDetails.Discount);
       }
       
       [Fact]
       //17
       public void GetOrderDetailByOrderId_ValidId_ReturnsProductNameUnitPriceAndQuantity()
       {
           var service = new DataService();
           var orderDetails = service.GetOrderDetailsByOrderId(10248);
           Assert.Equal(3, orderDetails.Count);
           Assert.Equal("Queso Cabrales", orderDetails.First().Product.Name);
           Assert.Equal(14, orderDetails.First().UnitPrice);
           Assert.Equal(12, orderDetails.First().Quantity);
       }

       [Fact]
       //18
       public void GetOrderDetailByProductId_ValidId_ReturnsOrderDateUnitPriceAndQuantity()
       {
           var service = new DataService();
           var orderDetails = service.GetOrderDetailsByProductId(11);
           Assert.Equal(38, orderDetails.Count);
           Assert.Equal("1996-07-04", orderDetails.First().Order.Date.ToString("yyyy-MM-dd"));
           Assert.Equal(14, orderDetails.First().UnitPrice);
           Assert.Equal(12, orderDetails.First().Quantity);
       }
    }
}
