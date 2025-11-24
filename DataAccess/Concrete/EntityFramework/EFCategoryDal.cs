using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EFCategoryDal : EfEntityRepositoryBase<Category, ApplicationDbContext>, ICategoryDal
{
    public override List<Category> GetAllByCategory(int categoryId)
    {
        using var context = new ApplicationDbContext();
        return context.Categories.Where(c => c.CategoryId == categoryId).ToList();
    }
}
