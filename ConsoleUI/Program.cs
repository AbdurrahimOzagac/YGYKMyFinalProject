using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EFProductDal());

        foreach (Product product in productManager.GetAllByCategoryId(2))
        {
            // System.Console.WriteLine(product.ProductName);
            // System.Console.WriteLine(product.CategoryId);
        }

        OrderManager orderManager = new OrderManager(new EFOrderDal());

        foreach (Order item in orderManager.GetAll())
        {
            //System.Console.WriteLine(item.ShipCity);
        }

        EFOrderDal efo = new();

        Console.WriteLine(string.Join("\n - ", efo.GetShipCities()));
    }
}