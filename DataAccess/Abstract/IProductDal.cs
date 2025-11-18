using System.Collections.Generic;
using System.Net.Http.Headers;
using Entities.Concrete;
namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        
    }
}