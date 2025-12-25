using System.Data;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        ProductTest();

        //DisplayShipCities();
    }

    private static void DisplayShipCities()
    {
        OrderManager orderManager = new OrderManager(new EFOrderDal());

        foreach (Order item in orderManager.GetAll())
        {
            //Console.WriteLine(item.ShipCity);
        }

        EFOrderDal efo = new();

        Console.WriteLine(string.Join("\n - ", efo.GetShipCities()));
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EFProductDal());

        var result = productManager.GetProductDetails();

        if (result.Success)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }
}