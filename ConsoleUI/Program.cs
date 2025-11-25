using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EFProductDal());

        foreach (Product product in productManager.GetAllByCategoryId(2))
        {
            System.Console.WriteLine(product.ProductName);
            System.Console.WriteLine(product.CategoryId);
        }

    }
}