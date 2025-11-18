using System.Collections.Generic;
using Bussiness.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
namespace Business.Concrete
{

    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public List<Product> GetAll()
        {
            // erişme yetkisi var mı?

            return _productDal.GetAll();
        }
    }
}