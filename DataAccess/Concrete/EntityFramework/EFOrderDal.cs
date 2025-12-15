using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EFOrderDal : EfEntityRepositoryBase<Order, NorthwindContext>, IOrderDal
{
    public List<string> GetShipCities()
    {
        using (NorthwindContext nw = new NorthwindContext())
        {
            return nw.Orders.Select(o => o.ShipCity).Distinct().ToList();
        }
    }
}