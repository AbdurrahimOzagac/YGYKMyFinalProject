using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EFProductDal : EfEntityRepositoryBase<Product, ApplicationDbContext>, IProductDal
{
    public override List<Product> GetAllByCategory(int categoryId)
    {
        using var context = new ApplicationDbContext();
        return context.Products.Where(p => p.CategoryId == categoryId).ToList();
    }
}
