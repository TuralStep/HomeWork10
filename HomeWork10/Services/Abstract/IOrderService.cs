using HomeWork10.Dots;
using HomeWork10.Entities;

namespace HomeWork10.Services.Abstract
{
    public interface IOrderService
    {
        public List<Order> GetAll();
        public Order GetById(int id);
        public void DeleteById(int id);
        public void UpdateById(int id, OrderDot customer);
    }
}
