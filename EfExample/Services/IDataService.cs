using System.Collections.Generic;

namespace EfExample
{
    public interface IDataService
    {
        Category CreateCategory(string name, string description);
        bool DeleteCategory(int id);
        List<Category> GetCategories();
        Category GetCategory(int id);
        Order GetOrder(int id);
        List<OrderDetails> GetOrderDetailsByOrderId(int id);
        List<OrderDetails> GetOrderDetailsByProductId(int id);
        List<dynamic> GetOrders();
        Product GetProduct(int id);
        List<Product> GetProductByCategory(int id);
        List<Product> GetProductByName(string s);
        bool UpdateCategory(int Id, string Name, string Description);
    }
}