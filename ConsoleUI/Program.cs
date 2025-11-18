using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new InMemoryProductDal());

        foreach (Product product in productManager.GetAll())
        {
            System.Console.WriteLine(product.ProductName);
        }
    }
}