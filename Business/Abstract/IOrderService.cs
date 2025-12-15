using Entities.Concrete;

namespace Business.Abstract;

public interface IOrderService
{
    List<Order> GetAll();
}