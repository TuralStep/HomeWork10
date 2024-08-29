using HomeWork10.Dots;
using HomeWork10.Entities;

namespace HomeWork10.Services.Abstract
{
    public interface ICustomerService
    {

        public List<Customer> GetAll();
        public Customer GetById(int id);
        public void DeleteById(int id);
        public void UpdateById(int id, CustomerDot customer);

    }
}
