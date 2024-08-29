using HomeWork10.Dots;
using HomeWork10.Entities;

namespace HomeWork10.Services.Abstract
{
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product GetById(int id);
        public void DeleteById(int id);
        public void UpdateById(int id, ProductDot customer);
    }
}
