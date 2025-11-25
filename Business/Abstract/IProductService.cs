using Entities.Concrete;

namespace Bussiness.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);

        List<Product> GetByUnitPrice(float min, float max);
    }
}